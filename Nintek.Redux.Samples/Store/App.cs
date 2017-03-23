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
            public class PrintTitle : IAction
            {
            }

            public class TitlePrinted : IAction
            {
            }
        }

        public class Epics
        {
            public class PrintTitle : Epic
            {
                public override IEnumerable<IAction> Execute(IAction action)
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
