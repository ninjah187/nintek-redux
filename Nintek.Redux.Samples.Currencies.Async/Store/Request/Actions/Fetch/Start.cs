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
    public class Start : Action<string>
    {
        public Start(string payload) : base(payload)
        {
        }
    }
}
