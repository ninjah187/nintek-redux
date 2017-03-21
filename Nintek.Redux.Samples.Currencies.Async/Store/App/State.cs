using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.App
{
    public class State
    {
        public Prompt.State Prompt { get; private set; }
        public Request.State Request { get; private set; }

        public State()
        {
            Prompt = new Prompt.State();
            Request = new Request.State();
        }

        public State(Prompt.State prompt, Request.State request)
        {
            Prompt = prompt;
            Request = request;
        }
    }
}
