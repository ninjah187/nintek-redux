using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux.Samples.Store;

namespace Nintek.Redux.Samples.Store
{
    public class AppRedux : Redux<AppState>
    {
        public static void Initialize()
        {
            CombineReducer<User.State, User.Reducer>();

            CreateEpic(() => new App.Epics.PrintTitle());
            CreateEpic(() => new Greeting.Epics.GreetUser());
        }
    }
}
