using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Prompt
{
    public class State
    {
        public string Text { get; private set; }

        public State()
        {
            Text = "";
        }

        public State(string text)
        {
            Text = text;
        }
    }
}
