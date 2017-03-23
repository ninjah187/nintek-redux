using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux.Core;

namespace Nintek.Redux
{
    public abstract class Redux<TAppState>
        where TAppState : new()
    {
        public static TAppState State { get; private set; }
        
        static ReducerDefinition[] _reducerDefinitions;
        static Epic[] _epics;

        static Redux()
        {
            State = new TAppState();
            _reducerDefinitions = new ReducerDefinition[0];
            _epics = new Epic[0];
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
            where TEpic : Epic
        {
            var epic = epicFactory();
            _epics = _epics.Concat(new[] { epic }).ToArray();
        }

        public static void Dispatch<TAction>()
            where TAction : IAction
        {
            var action = (IAction) Activator.CreateInstance(typeof(TAction));
            Dispatch(action);
        }

        public static void Dispatch<TAction, TPayload>(TPayload payload)
            where TAction : IAction<TPayload>
        {
            var action = (IAction) Activator.CreateInstance(typeof(TAction), payload);
            Dispatch(action);
        }

        static void Dispatch(IAction action)
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
                    property.SetValue(obj, newState);
                }
            });

            ExecuteEpics(action);
        }

        static void ExecuteEpics(IAction action)
        {
            foreach (var epic in _epics)
            {
                var outputActions = epic.Execute(action);
                foreach (var outAction in outputActions)
                {
                    Dispatch(outAction);
                }
            }
        }
    }
}
