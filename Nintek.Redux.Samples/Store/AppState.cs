using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux.Samples.Store;

namespace Nintek.Redux.Samples.Store
{
    public class AppState
    {
        public string Title { get; }

        public User.State User { get; }

        public AppState()
        {
            Title = "Nintek.Redux Hello World app";
        }
    }
}
