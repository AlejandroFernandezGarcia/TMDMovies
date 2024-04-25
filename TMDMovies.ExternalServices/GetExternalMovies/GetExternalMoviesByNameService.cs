
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TMDMovies.Commons;
using TMDMovies.Commons.Helpers;
using TMDMovies.ExternalServices.Models;

namespace TMDMovies.ExternalServices.GetExternalMovies
{
    public class GetExternalMoviesByNameService : IService<GetExternalMoviesByNameQuery, GetExternalMoviesByNameResult>
    {
        private IHttpClientHelper _httpClientHelper;
        private IMapper _mapper;

        public GetExternalMoviesByNameService(IHttpClientHelper httpClientHelper, IMapper mapper)
        {
            _httpClientHelper = httpClientHelper;
            _mapper = mapper;
        }

        public GetExternalMoviesByNameResult Execute(GetExternalMoviesByNameQuery query)
        {
            string url = "https://api.themoviedb.org/3/search/movie";
            Dictionary<string, string> queryParams = new Dictionary<string, string>()
            {
                { "query", query.Name}
            };
            string tokenJwt = "";

            var response = _httpClientHelper.Get(url, queryParams, tokenJwt);

            if (!String.IsNullOrEmpty(response))
            {
                var parsedObject = JObject.Parse(response);
                TMDBMovieResponse firstMovie = JsonConvert.DeserializeObject<TMDBMovieResponse>(parsedObject["results"][0].ToString());

                return _mapper.Map<GetExternalMoviesByNameResult>(firstMovie);

            }

            return new GetExternalMoviesByNameResult();
        }
    }
}
