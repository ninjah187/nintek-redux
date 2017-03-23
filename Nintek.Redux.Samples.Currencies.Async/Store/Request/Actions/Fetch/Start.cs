using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Request.Actions.Fetch
{
    /// <summary>
    /// Payload is URL of data.
    /// </summary>
    public class Start : IAction<string>
    {
        public string Payload { get; }

        public Start(string payload)
        {
            Payload = payload;
        }
    }
}
