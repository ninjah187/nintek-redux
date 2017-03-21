using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Async.Services
{
    public interface IHttpService
    {
        Task<string> GetAsync(string url);
    }
}
