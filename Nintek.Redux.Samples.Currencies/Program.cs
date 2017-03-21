using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux.Samples.Currencies.Store;

namespace Nintek.Redux.Samples.Currencies
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppRedux.Init();

            AppRedux.Dispatch<Prompts.Actions.PromptUser>();

            Console.ReadKey();
        }
    }
}
