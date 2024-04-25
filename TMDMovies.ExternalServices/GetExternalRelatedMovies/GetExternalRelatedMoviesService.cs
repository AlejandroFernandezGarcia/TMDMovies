using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDMovies.Commons;

namespace TMDMovies.ExternalServices.GetExternalRelatedMovies
{
    public class GetExternalRelatedMoviesService : IService<GetExternalRelatedMoviesQuery, GetExternalRelatedMoviesResult>
    {
        public GetExternalRelatedMoviesService() { }

        public GetExternalRelatedMoviesResult Execute(GetExternalRelatedMoviesQuery input)
        {
            throw new NotImplementedException();
        }
    }
}
