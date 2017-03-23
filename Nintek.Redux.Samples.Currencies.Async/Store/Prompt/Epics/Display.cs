using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Prompt.Epics
{
    public class Display : Epic
    {
        public override IEnumerable<IAction> Execute(IAction input)
        {
            switch (input)
            {
                case Actions.Display display:
                    //Console.Clear();
                    Console.WriteLine(display.Payload);
                    Console.Write("> ");
                    var url = Console.ReadLine();
                    yield return new Request.Actions.Fetch.Start(url); 
                    yield break;
            }
        }
    }
}
