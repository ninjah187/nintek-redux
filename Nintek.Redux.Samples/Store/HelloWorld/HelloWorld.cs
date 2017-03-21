using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Store.HelloWorld
{
    public class HelloWorld
    {
        public class Actions
        {
            public static string MESSAGE__PRINT_ON_CONSOLE { get; } = $"{nameof(HelloWorld)}__{nameof(MESSAGE__PRINT_ON_CONSOLE)}";
        }
    }
}
