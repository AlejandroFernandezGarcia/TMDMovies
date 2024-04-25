using AutoMapper;
using TMDMovies.Commons;
using TMDMovies.ExternalServices.GetExternalMovies;
using TMDMovies.ExternalServices.GetExternalRelatedMovies;
using System.Linq;

namespace TMDMovies.Services.GetMovies
{
    public class GetMoviesByNameService : IService<GetMoviesByNameQuery, GetMoviesByNameResult>
    {
        private IService<GetExternalMoviesByNameQuery, GetExternalMoviesByNameResult> _getExternalMovieService;
        private IService<GetExternalRelatedMoviesQuery, GetExternalRelatedMoviesResult> _getExternalRelatedMovieService;
        private IMapper _mapper;

        public GetMoviesByNameService(
            IService<GetExternalMoviesByNameQuery, GetExternalMoviesByNameResult> getExternalMovieService,
            IService<GetExternalRelatedMoviesQuery, GetExternalRelatedMoviesResult> getExternalRelatedMovieService,
            IMapper mapper)
        {
            _getExternalMovieService = getExternalMovieService;
            _getExternalRelatedMovieService = getExternalRelatedMovieService;
            _mapper = mapper;
        }

        public GetMoviesByNameResult Execute(GetMoviesByNameQuery query)
        {
            GetExternalMoviesByNameResult movieResult = _getExternalMovieService.Execute(_mapper.Map<GetExternalMoviesByNameQuery>(query));
            GetExternalRelatedMoviesResult relatedMovieResult = _getExternalRelatedMovieService.Execute(new GetExternalRelatedMoviesQuery(movieResult.Id));

            GetMoviesByNameResult movie = _mapper.Map<GetMoviesByNameResult>(movieResult);
            movie.RelatedMovies = relatedMovieResult.relatedMovies.Select(x => $"{x.Title} ({x.ReleaseYear})").ToList();

            return movie;
        }
    }
}
