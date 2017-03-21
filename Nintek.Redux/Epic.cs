using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux
{
    public abstract class Epic
    {
        public abstract void Execute(Action action);
    }
}
