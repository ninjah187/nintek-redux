using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux;
using Nintek.Redux.Samples.Currencies.Async.Services;

namespace Nintek.Redux.Samples.Currencies.Async.Store
{
    public class AppRedux : Redux<App.State>
    {
        public static void Init()
        {
            CreateEpic(() => new App.Epics.LoggerEpic());
            CreateEpic(() => new App.Epics.DisplayMessage());

            CombineReducer<Prompt.State, Prompt.Reducer>();
            CreateEpic(() => new Prompt.Epics.Display());

            CombineReducer<Request.State, Request.Reducer>();
            CreateEpic(() => new Request.Epics.Fetch(new HttpService()));
        }
    }
}
