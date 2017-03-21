using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux
{
    public class Reducer
    {
        protected Func<object, Action, object> ReduceFunc { get; set; }

        public object Reduce(object state, Action action)
            => ReduceFunc(state, action);
    }

    public abstract class Reducer<TState> : Reducer
    {
        public Reducer()
        {
            ReduceFunc = (state, action) =>
            {
                if (!state.GetType().IsAssignableFrom(typeof(TState)))
                {
                    return state;
                }

                return Reduce((TState) state, action);
            };
        }

        public abstract TState Reduce(TState state, Action action);
    }
}
