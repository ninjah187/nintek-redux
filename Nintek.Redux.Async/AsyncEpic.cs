using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux
{
    public abstract class AsyncEpic : IEpic
    {
        public abstract Task<IEnumerable<Action>> ExecuteAsync(Action input);
    }
}
