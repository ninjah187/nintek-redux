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
    public class Success : Action<string>
    {
        public Success(string payload) : base(payload)
        {
        }
    }
}
