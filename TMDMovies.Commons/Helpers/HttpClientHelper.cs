using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TMDMovies.Commons.Exceptions;

namespace TMDMovies.Commons.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public string Get(string url, string tokenJWT, Dictionary<string, string> queryParams = null)
        {
            HttpClient client = new HttpClient();

            #region Headers

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);

            #endregion

            string queryParamsStr = "";
            if ((queryParams?.Count ?? 0) > 0)
                queryParamsStr = "?" + queryParams
                .Select(kv => kv.Key.ToString() + "=" + HttpUtility.UrlEncode(kv.Value.ToString()))
                .Aggregate((a, b) => a + "&" + b);

            try
            {
                var response = client.GetAsync($"{url}{queryParamsStr}").GetAwaiter().GetResult();
                if (!response.IsSuccessStatusCode)
                    throw new ExternalServiceException($"Get method unsuccess result ({response.StatusCode})");

                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            }
            catch (Exception e)
            {
                throw new ExternalServiceException("Error to query external service", e);
            }
        }
    }
}
