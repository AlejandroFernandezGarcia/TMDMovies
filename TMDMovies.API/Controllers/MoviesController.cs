using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMDMovies.API.Models;
using TMDMovies.Commons;
using TMDMovies.Services.GetMovies;

namespace TMDMovies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IService<GetMoviesByNameQuery, GetMoviesByNameResult> _getMoviesByNameService;
        private IMapper _mapper;

        public MoviesController(IService<GetMoviesByNameQuery, GetMoviesByNameResult> getMoviesByNameService, IMapper mapper)
        {
            _getMoviesByNameService = getMoviesByNameService;
            _mapper = mapper;
        }        

        // GET: api/<MoviesController>
        [HttpGet("{Name}")]
        public IActionResult Get([FromRoute] GetMoviesRequest request)
        {            
            var result =_getMoviesByNameService.Execute(_mapper.Map<GetMoviesByNameQuery>(request));

            return Ok(_mapper.Map<MovieResponse>(result));
        }
    }
}
