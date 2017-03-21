using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Prompt
{
    public class Reducer : Reducer<State>
    {
        public override State Reduce(State state, Action action)
        {
            switch (action)
            {
                case Actions.Display display:
                    return new State(display.Payload);

                default:
                    return state;
            }
        }
    }
}
