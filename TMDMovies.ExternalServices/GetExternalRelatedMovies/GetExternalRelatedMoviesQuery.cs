using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDMovies.ExternalServices.GetExternalRelatedMovies
{
    public class GetExternalRelatedMoviesQuery
    {
        public GetExternalRelatedMoviesQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
