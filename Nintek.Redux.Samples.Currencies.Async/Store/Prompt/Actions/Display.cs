using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Prompt.Actions
{
    /// <summary>
    /// Payload is text which will be displayed with prompt.
    /// </summary>
    public class Display : IAction<string>
    {
        public string Payload { get; }

        public Display(string payload)
        {
            Payload = payload;
        }
    }
}
