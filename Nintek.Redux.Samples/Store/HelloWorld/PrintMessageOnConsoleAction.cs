using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Store.HelloWorld
{
    public class PrintMessageOnConsoleAction : Action
    {
        public PrintMessageOnConsoleAction() 
            : base(HelloWorld.Actions.MESSAGE__PRINT_ON_CONSOLE)
        {
        }
    }
}
