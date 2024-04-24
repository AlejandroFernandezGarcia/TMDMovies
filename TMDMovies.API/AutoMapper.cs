using AutoMapper;
using TMDMovies.API.Models;
using TMDMovies.Services.GetMovies;

namespace TMDMovies.API
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<GetMoviesRequest, GetMoviesByNameQuery>();
        }
    }
}
