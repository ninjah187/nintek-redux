using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Store
{
    public class AppRedux : Redux<App.State>
    {
        public static void Init()
        {
            CombineReducer<App.State, App.Reducer>();
            CombineReducer<Prompts.State, Prompts.Reducer>();
            CombineReducer<CurrencyRates.State, CurrencyRates.Reducer>();
            
            CreateEpic(() => new App.Epics.DisplayText());
            CreateEpic(() => new Prompts.Epics.PromptUser());
            CreateEpic(() => new CurrencyRates.Epics.Request());
        }
    }
}
