using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDMovies.Commons;
using TMDMovies.Commons.Helpers;
using TMDMovies.ExternalServices.GetExternalMovies;
using TMDMovies.ExternalServices.Models;

namespace TMDMovies.ExternalServices.GetExternalRelatedMovies
{
    public class GetExternalRelatedMoviesService : IService<GetExternalRelatedMoviesQuery, GetExternalRelatedMoviesResult>
    {
        private IHttpClientHelper _httpClientHelper;
        private IMapper _mapper;
        private IOptions<AppSettings> _options;

        public GetExternalRelatedMoviesService(IHttpClientHelper httpClientHelper, IMapper mapper, IOptions<AppSettings> options)
        {
            _httpClientHelper = httpClientHelper;
            _mapper = mapper;
            _options = options;
        }

        public GetExternalRelatedMoviesResult Execute(GetExternalRelatedMoviesQuery query)
        {
            string url = $"https://api.themoviedb.org/3/movie/{query.Id}/similar";
            string tokenJwt = _options.Value.TMDBJwtToken;

            var response = _httpClientHelper.Get(url, tokenJwt);

            var parsedObject = JObject.Parse(response);

            if (((int)parsedObject["total_results"]) > 0)
            {
                List<TMDBMovieResponse> relatedMovies = parsedObject["results"].Take(5).Select(x => JsonConvert.DeserializeObject<TMDBMovieResponse>(x.ToString())).ToList();

                return new GetExternalRelatedMoviesResult(relatedMovies.Select(x => new RelatedMovie()
                {
                    Title = x.Title,
                    ReleaseYear = DateTime.Parse(x.ReleaseDAte).Year
                }).ToList());
            }

            return new GetExternalRelatedMoviesResult();
        }
    }
}
