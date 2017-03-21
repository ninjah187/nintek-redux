using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux
{
    public class ReducerDefinition
    {
        public Type StateType { get; }
        public Reducer Reducer { get; }

        public ReducerDefinition(Type stateType, Reducer reducer)
        {
            StateType = stateType;
            Reducer = reducer;
        }
    }
}
