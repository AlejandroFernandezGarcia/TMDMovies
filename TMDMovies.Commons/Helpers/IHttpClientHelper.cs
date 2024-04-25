using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDMovies.Commons.Helpers
{
    public interface IHttpClientHelper
    {
        string Get(string url, Dictionary<string, string> queryParams, string tokenJWT);
    }
}
