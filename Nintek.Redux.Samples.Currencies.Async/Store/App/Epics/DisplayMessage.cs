using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.App.Epics
{
    public class DisplayMessage : Epic
    {
        public override IEnumerable<Action> Execute(Action input)
        {
            switch (input)
            {
                case Request.Actions.Fetch.Success success:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(success.Payload);
                    Console.ResetColor();
                    Console.ReadKey();
                    yield return new Prompt.Actions.Display("Fetch data from URL:");
                    yield break;

                case Request.Actions.Fetch.Failure failure:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(failure.Payload);
                    Console.ResetColor();
                    Console.ReadKey();
                    yield return new Prompt.Actions.Display("Fetch data from URL:");
                    yield break;
            }
        }
    }
}
