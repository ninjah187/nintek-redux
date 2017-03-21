using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Store
{
    public class Greeting
    {
        public class Actions
        {
            public static string GREET_USER_ON_CONSOLE { get; }
                = "GREETING__GREET_USER";

            public class GreetUser : Action
            {
                public GreetUser()
                    : base(GREET_USER_ON_CONSOLE)
                {
                }
            }
        }

        public class Epics
        {
            public class GreetUser : Epic
            {
                public override void Execute(Action input)
                {
                    switch (input)
                    {
                        case Actions.GreetUser action:
                            Console.WriteLine($"Hi, {AppRedux.State.User.Name}!");
                            break;
                    }
                }
            }
        }
    }
}
