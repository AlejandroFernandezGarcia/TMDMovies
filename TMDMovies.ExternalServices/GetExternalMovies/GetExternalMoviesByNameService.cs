
using AutoMapper;
using Microsoft.Extensions.Options;
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
        private IOptions<AppSettings> _options;

        public GetExternalMoviesByNameService(IHttpClientHelper httpClientHelper, IMapper mapper, IOptions<AppSettings> options)
        {
            _httpClientHelper = httpClientHelper;
            _mapper = mapper;
            _options = options;
        }

        public GetExternalMoviesByNameResult Execute(GetExternalMoviesByNameQuery query)
        {
            string url = "https://api.themoviedb.org/3/search/movie";
            Dictionary<string, string> queryParams = new Dictionary<string, string>()
            {
                { "query", query.Name}
            };
            string tokenJwt = _options.Value.TMDBJwtToken;

            var response = _httpClientHelper.Get(url, tokenJwt, queryParams);

            var parsedObject = JObject.Parse(response);

            if (((int)parsedObject["total_results"]) > 0)
            {
                TMDBMovieResponse firstMovie = JsonConvert.DeserializeObject<TMDBMovieResponse>(parsedObject["results"].Take(1).ToString());

                return _mapper.Map<GetExternalMoviesByNameResult>(firstMovie);
            }

            return new GetExternalMoviesByNameResult();
        }
    }
}
