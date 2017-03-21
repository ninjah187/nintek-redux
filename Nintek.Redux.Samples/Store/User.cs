using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Store
{
    public class User
    {
        public class State
        {
            public string Name { get; private set; }

            public State()
            {
                Name = "";
            }

            public State(string name)
            {
                Name = name;
            }
        }

        public class Actions
        {
            public class SignIn : Action<string>
            {
                public SignIn(string payload) : base(payload)
                {
                }
            }
        }

        public class Reducer : Reducer<State>
        {
            public override State Reduce(State state, Action input)
            {
                switch (input)
                {
                    case Actions.SignIn action:
                        return new State(action.Payload);

                    default:
                        return state;
                }
            }
        }
    }
}
