using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Actions
{
    public class ChangeNameAction : Action<string>
    {
        public ChangeNameAction(string payload) 
            : base("ChangeName__BY_VALUE", payload)
        {
        }
    }
}
