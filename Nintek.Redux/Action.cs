using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux
{
    public class Action
    {
    }

    public class Action<TPayload> : Action
    {
        public TPayload Payload { get; }

        public Action(TPayload payload)
        {
            Payload = payload;
        }
    }
}
