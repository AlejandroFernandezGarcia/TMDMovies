using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDMovies.Commons;
using TMDMovies.ExternalServices.Models;

namespace TMDMovies.ExternalServices.GetExternalRelatedMovies
{
    public class GetExternalRelatedMoviesResult
    {
        public List<TMDBMovieResponse> RelatedMovies { get; set; }

        public GetExternalRelatedMoviesResult()
        {
            RelatedMovies = new List<TMDBMovieResponse>();
        }
        public GetExternalRelatedMoviesResult(List<TMDBMovieResponse> relatedMovies)
        {
            RelatedMovies = relatedMovies;
        }
    }
}
