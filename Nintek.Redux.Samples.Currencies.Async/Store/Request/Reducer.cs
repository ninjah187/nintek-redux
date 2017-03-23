using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Request
{
    public class Reducer : Reducer<State>
    {
        public override State Reduce(State state, IAction action)
        {
            switch (action)
            {
                case Actions.Fetch.Start start:
                    return new State(start.Payload, true, null);

                case Actions.Fetch.Success success:
                    return new State(state.Url, false, success.Payload);

                case Actions.Fetch.Failure failure:
                    return new State(state.Url, false, failure.Payload);

                default:
                    return state;
            }
        }
    }
}
