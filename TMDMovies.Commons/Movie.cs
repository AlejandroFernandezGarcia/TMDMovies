using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDMovies.Commons
{
    public class Movie
    {
        public string Title { get; set; }

        public List<RelatedMovie> relatedMovies { get; set; }
    }
}
