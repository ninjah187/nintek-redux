using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Request.Actions.Fetch
{
    /// <summary>
    /// Payload is fetched data.
    /// </summary>
    public class Success : IAction<string>
    {
        public string Payload { get; }

        public Success(string payload)
        {
            Payload = payload;
        }
    }
}
