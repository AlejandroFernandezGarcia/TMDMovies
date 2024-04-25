using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDMovies.ExternalServices.Models;

namespace TMDMovies.ExternalServices.GetExternalMovies
{
    public class GetExternalMoviesByNameResult
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string ScoreAverage { get; set; }
        public DateTime ReleaseDAte { get; set; }
        public string Synopsis { get; set; }
    }
}
