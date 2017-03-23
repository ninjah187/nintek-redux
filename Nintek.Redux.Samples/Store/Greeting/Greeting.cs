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
            public class GreetUser : IAction
            {
            }

            public class UserGreeted : IAction
            {
            }
        }

        public class Epics
        {
            public class GreetUser : Epic
            {
                public override IEnumerable<IAction> Execute(IAction input)
                {
                    switch (input)
                    {
                        case Actions.GreetUser action:
                            Console.WriteLine($"Hi, {AppRedux.State.User.Name}!");
                            yield return new Actions.UserGreeted();
                            yield break;
                    }
                }
            }
        }
    }
}
