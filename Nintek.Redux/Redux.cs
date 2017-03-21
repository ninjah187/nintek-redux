using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Utils;

namespace Nintek.Redux
{
    public abstract class Redux<TAppState>
        where TAppState : new()
    {
        public static TAppState State { get; private set; }

        //static Reducer[] _reducers;
        static ReducerDefinition[] _reducerDefinitions;
        static Epic[] _epics;

        static Redux()
        {
            State = new TAppState();
            //_reducers = new Reducer[0];
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
            //_reducers = _reducers.Concat(new[] { reducer }).ToArray();
        }

        public static void CreateEpic<TEpic>(Func<TEpic> epicFactory)
            where TEpic : Epic, new()
        {
            var epic = epicFactory();
            _epics = _epics.Concat(new[] { epic }).ToArray();
        }

        public static void Dispatch<TAction>()
            where TAction : Action
        {
            var action = (Action) Activator.CreateInstance(typeof(TAction));
            
            

            ExecuteEpics(action);
        }

        public static void Dispatch<TAction, TPayload>(TPayload payload)
            where TAction : Action<TPayload>
        {
            var action = (Action) Activator.CreateInstance(typeof(TAction), payload);

            //foreach (var reducer in _reducers)
            //{
            //    //State = reducer.Reduce<TAppState, Action>(State, action);
            //}

            //var newState = ;

            State.WalkOverProperties((obj, property) =>
            {
                
            });

            ExecuteEpics(action);
        }

        static void ExecuteEpics(Action action)
        {
            foreach (var epic in _epics)
            {
                epic.Execute(action);
            }
        }
    }
}
