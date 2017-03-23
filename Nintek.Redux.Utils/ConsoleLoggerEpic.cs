using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux.Core;

namespace Nintek.Redux.Utils
{
    public class ConsoleLoggerEpic : Epic
    {
        readonly string _storeNameSpacePrefixToSkip;

        public ConsoleLoggerEpic(string storeNameSpacePrefixToSkip)
        {
            _storeNameSpacePrefixToSkip = storeNameSpacePrefixToSkip;
        }

        public override IEnumerable<IAction> Execute(IAction input)
        {
            var actionName = input.GetType().FullName.Replace(_storeNameSpacePrefixToSkip, "");
            var payload = input.GetPayload()?.ToString();

            var logMessage = string.Join(" ", actionName, payload);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"@@ {logMessage}");
            Console.ResetColor();
            yield break;
        }
    }
}
