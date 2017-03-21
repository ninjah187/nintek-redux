using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux
{
    public class Action
    {
        public string Type { get; }

        public Action(string type)
        {
            Type = type;
        }
    }

    public class Action<TPayload> : Action
    {
        public TPayload Payload { get; }

        public Action(string type, TPayload payload)
            : base(type)
        {
            Payload = payload;
        }
    }
}
