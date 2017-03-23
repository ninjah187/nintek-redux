using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux.Core;

namespace Nintek.Redux
{
    public class Redux<TAppState>
        where TAppState : new()
    {
        public static TAppState State { get; private set; }

        static ReducerDefinition[] _reducerDefinitions;
        static IEpic[] _epics;

        static Redux()
        {
            State = new TAppState();
            _reducerDefinitions = new ReducerDefinition[0];
            _epics = new IEpic[0];
        }

        public static void CombineReducer<TState, TReducer>()
            where TReducer : Reducer<TState>
        {
            var reducer = Activator.CreateInstance<TReducer>();
            _reducerDefinitions = _reducerDefinitions
                .Concat(new[] { new ReducerDefinition(typeof(TState), reducer) })
                .ToArray();
        }

        public static void CreateEpic<TEpic>(Func<TEpic> epicFactory)
            where TEpic : IEpic
        {
            var epic = epicFactory();
            _epics = _epics.Concat(new IEpic[] { epic }).ToArray();
        }

        public static async Task DispatchAsync<TAction>()
            where TAction : IAction
        {
            var action = (IAction)Activator.CreateInstance(typeof(TAction));
            await DispatchAsync(action);
        }

        public static async Task DispatchAsync<TAction, TPayload>(TPayload payload)
            where TAction : IAction<TPayload>
        {
            var action = (IAction)Activator.CreateInstance(typeof(TAction), payload);
            await DispatchAsync(action);
        }

        static async Task DispatchAsync(IAction action)
        {
            var rootReducers = _reducerDefinitions
                .Where(definition => definition.StateType == typeof(TAppState))
                .Select(definition => definition.Reducer);

            foreach (var reducer in rootReducers)
            {
                var newState = reducer.Reduce(State, action);
                State = (TAppState)newState;
            }

            State.WalkOverProperties((obj, property) =>
            {
                var reducers = _reducerDefinitions
                    .Where(definition => definition.StateType == property.PropertyType)
                    .Select(definition => definition.Reducer);

                foreach (var reducer in reducers)
                {
                    var state = property.GetValue(obj);
                    var newState = reducer.Reduce(state, action);
                    if (state != newState)
                    {
                        property.SetValue(obj, newState);
                    }
                }
            });

            await ExecuteEpicsAsync(action);
        }

        static async Task ExecuteEpicsAsync(IAction action)
        {
            foreach (var epic in _epics)
            {
                IEnumerable<IAction> outActions = Enumerable.Empty<IAction>();

                switch (epic)
                {
                    case Epic syncEpic:
                        outActions = syncEpic.Execute(action);
                        break;

                    case EpicAsync asyncEpic:
                        outActions = await asyncEpic.ExecuteAsync(action);
                        break;
                }

                foreach (var outAction in outActions)
                {
                    await DispatchAsync(outAction);
                }
            }
        }
    }
}
