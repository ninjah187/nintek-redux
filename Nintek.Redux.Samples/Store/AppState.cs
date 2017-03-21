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
        public string Title { get; private set; }

        public User.State User { get; private set; }

        public AppState()
        {
            Title = "Nintek.Redux Hello World app";
            User = new User.State();
        }
    }
}
