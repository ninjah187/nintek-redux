using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux.Samples.Store;

namespace Nintek.Redux.Samples
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppRedux.Initialize();

            AppRedux.Dispatch<App.Actions.PrintTitle>();
            AppRedux.Dispatch<User.Actions.SignIn, string>("Karol");
            AppRedux.Dispatch<Greeting.Actions.GreetUser>();
            
            Console.ReadKey();
        }
    }
}
