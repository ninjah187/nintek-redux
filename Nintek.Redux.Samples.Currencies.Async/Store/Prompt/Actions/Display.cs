using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Prompt.Actions
{
    public class Display : Action<string>
    {
        public Display(string payload) : base(payload)
        {
        }
    }
}
