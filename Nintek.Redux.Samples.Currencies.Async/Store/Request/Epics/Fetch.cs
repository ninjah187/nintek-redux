using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Redux.Samples.Currencies.Async.Services;

namespace Nintek.Redux.Samples.Currencies.Async.Store.Request.Epics
{
    public class Fetch : AsyncEpic
    {
        readonly IHttpService _http;

        public Fetch(IHttpService http)
        {
            _http = new HttpService();
        }

        public override async Task<IEnumerable<Action>> ExecuteAsync(Action input)
        {
            var output = new List<Action>();

            switch (input)
            {
                case Actions.Fetch.Start start:
                    try
                    {
                        var data = await _http.GetAsync(AppRedux.State.Request.Url);
                        output.Add(new Actions.Fetch.Success(data));
                    }
                    catch (Exception exc)
                    {
                        output.Add(new Actions.Fetch.Failure(exc.ToString()));
                    }
                    break;
            }

            return output;
        }
    }
}
