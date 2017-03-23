using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux
{
    public interface IAction
    {
    }

    public interface IAction<TPayload> : IAction
    {
        TPayload Payload { get; }
    }
}
