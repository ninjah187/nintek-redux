using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux.Samples.Currencies.Async.Store;

namespace Nintek.Redux.Samples.Currencies.Async
{
    class Program
    {
        static async Task MainAsync()
        {
            AppRedux.Init();

            await AppRedux.DispatchAsync<Store.Prompt.Actions.Display, string>("Fetch data from URL:");

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
    }
}
