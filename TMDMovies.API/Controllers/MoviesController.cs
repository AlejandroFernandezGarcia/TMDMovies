using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMDMovies.API.Models;
using TMDMovies.Commons;
using TMDMovies.Services.GetMovies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpGet]
        public IEnumerable<MovieListResponse> Get([FromQuery] GetMoviesRequest request)
        {
            
            var result =_getMoviesByNameService.Execute(_mapper.Map<GetMoviesByNameQuery>(request));

            throw new NotImplementedException();
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
