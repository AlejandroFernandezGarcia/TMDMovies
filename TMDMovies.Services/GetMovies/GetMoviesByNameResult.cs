using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDMovies.Services.GetMovies
{
    public class GetMoviesByNameResult
    {
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string ScoreAverage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Synopsis { get; set; }
        public List<string> RelatedMovies { get; set; }
    }
}
