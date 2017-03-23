using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux
{
    public abstract class EpicAsync : IEpic
    {
        public abstract Task<IEnumerable<IAction>> ExecuteAsync(IAction input);
    }
}
