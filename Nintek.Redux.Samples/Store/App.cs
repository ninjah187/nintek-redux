﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Store
{
    public class App
    {
        public class Actions
        {
            public static string TITLE__PRINT_ON_CONSOLE { get; } 
                = $"{nameof(App)}__{nameof(TITLE__PRINT_ON_CONSOLE)}";

            public class PrintTitleOnConsole : Action
            {
                public PrintTitleOnConsole()
                    : base(TITLE__PRINT_ON_CONSOLE)
                {
                }
            }
        }

        public class Epics
        {
            public class PrintTitleOnConsole : Epic
            {
                public override void Execute(Action action)
                {
                    switch (action)
                    {
                        case Actions.PrintTitleOnConsole act:
                            Console.WriteLine($">> {AppRedux.State.Title}");
                            break;
                    }
                }
            }
        }
    }
}
