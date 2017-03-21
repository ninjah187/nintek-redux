using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Store
{
    public class App
    {
        public class Actions
        {
            public class PrintTitle : Action
            {
            }

            public class TitlePrinted : Action
            {
            }
        }

        public class Epics
        {
            public class PrintTitle : Epic
            {
                public override IEnumerable<Action> Execute(Action action)
                {
                    switch (action)
                    {
                        case Actions.PrintTitle act:
                            Console.WriteLine($">> {AppRedux.State.Title}");
                            yield return new Actions.TitlePrinted();
                            yield break;
                    }
                }
            }
        }
    }
}
