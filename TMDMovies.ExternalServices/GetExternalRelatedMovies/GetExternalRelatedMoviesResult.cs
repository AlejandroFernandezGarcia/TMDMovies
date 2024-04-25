using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDMovies.Commons;

namespace TMDMovies.ExternalServices.GetExternalRelatedMovies
{
    public class GetExternalRelatedMoviesResult
    {
        public List<RelatedMovie> RelatedMovies { get; set; }

        public GetExternalRelatedMoviesResult()
        {
            RelatedMovies = new List<RelatedMovie>();
        }
        public GetExternalRelatedMoviesResult(List<RelatedMovie> relatedMovies)
        {
            RelatedMovies = relatedMovies;
        }
    }
}
