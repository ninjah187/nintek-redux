using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Request
{
    public class State
    {
        public string Url { get; private set; }
        public bool IsFetching { get; private set; }
        public string Data { get; private set; }

        public State()
        {
        }

        public State(string url, bool isFetching, string data)
        {
            Url = url;
            IsFetching = isFetching;
            Data = data;
        }
    }
}
