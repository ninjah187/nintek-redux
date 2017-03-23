using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.App.Epics
{
    public class LoggerEpic : Epic
    {
        public override IEnumerable<IAction> Execute(IAction input)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(
                $"@@ {input.GetType().FullName.Replace("Nintek.Redux.Samples.Currencies.Async.Store.", "")}");
            Console.ResetColor();
            yield break;
        }
    }
}
