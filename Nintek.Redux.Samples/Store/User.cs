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
            public string Name { get; }

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
            public static string SIGN_IN { get; }
                = $"{nameof(User)}__{nameof(SIGN_IN)}";

            public class SignIn : Action<string>
            {
                public SignIn(string payload) 
                    : base(SIGN_IN, payload)
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
