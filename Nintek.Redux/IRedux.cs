using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux
{
    public interface IRedux<TAppState>
        where TAppState : new()
    {
        TAppState State { get; }
    }
}
