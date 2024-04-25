using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TMDMovies.Commons.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public string Get(string url, Dictionary<string, string> queryParams, string tokenJWT)
        {
            HttpClient client = new HttpClient();

            #region Headers

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);

            #endregion

            string queryParamsStr = queryParams
                .Select(kv => kv.Key.ToString() + "=" + HttpUtility.UrlEncode(kv.Value.ToString()))
                .Aggregate((a,b)=> a + "&" + b);

            try
            {
                var response = client.GetAsync($"{url}?{queryParamsStr}").GetAwaiter().GetResult();
                if (!response.IsSuccessStatusCode)
                    throw new Exception("TMDB error");

                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            }catch(Exception e)
            {
                throw new Exception("TMDB error", e);
            }
        }
    }
}
