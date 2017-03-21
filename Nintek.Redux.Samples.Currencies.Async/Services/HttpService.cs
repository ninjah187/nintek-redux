using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Nintek.Redux.Samples.Currencies.Async.Services
{
    public class HttpService : IHttpService
    {
        public async Task<string> GetAsync(string url)
        {
            using (var client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(url);
            }
        }
    }
}
