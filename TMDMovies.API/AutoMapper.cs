using AutoMapper;
using TMDMovies.API.Models;
using TMDMovies.ExternalServices.GetExternalMovies;
using TMDMovies.ExternalServices.Models;
using TMDMovies.Services.GetMovies;

namespace TMDMovies.API
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<GetMoviesRequest, GetMoviesByNameQuery>();
            CreateMap<GetMoviesByNameResult, MovieResponse>();
            CreateMap<GetMoviesByNameQuery, GetExternalMoviesByNameQuery>();
            CreateMap<TMDBMovieResponse, GetExternalMoviesByNameResult>();
            CreateMap<GetExternalMoviesByNameResult, GetMoviesByNameResult>();
        }
    }
}
