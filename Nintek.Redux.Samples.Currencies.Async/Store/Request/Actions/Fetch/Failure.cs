using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Request.Actions.Fetch
{
    /// <summary>
    /// Payload is error message.
    /// </summary>
    public class Failure : IAction<string>
    {
        public string Payload { get; }

        public Failure(string payload)
        {
            Payload = payload;
        }
    }
}
