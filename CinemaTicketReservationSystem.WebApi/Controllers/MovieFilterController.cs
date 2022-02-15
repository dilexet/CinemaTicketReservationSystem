using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.WebApi.Models.Filters;
using CinemaTicketReservationSystem.WebApi.Models.Response.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Response.MovieFilter;
using CinemaTicketReservationSystem.WebApi.Models.Response.Search;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieFilterController : ControllerBase
    {
        private readonly IMovieFilterService _movieFilterService;
        private readonly IMapper _mapper;

        public MovieFilterController(IMovieFilterService movieFilterService, IMapper mapper)
        {
            _movieFilterService = movieFilterService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesByFilter([FromQuery] MovieFilterParametersRequest filter)
        {
            var movieResult =
                await _movieFilterService.GetMoviesByFilter(_mapper.Map<MovieFilterParametersModel>(filter));
            var response = _mapper.Map<MovieGetAllResponse>(movieResult);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionsForMovie([FromRoute] MovieRequestWrapper movieRequestWrapper)
        {
            var sessionsResult = await _movieFilterService.GetSessionsForMovie(movieRequestWrapper.Id);
            var response = _mapper.Map<GetSessionsResponse>(sessionsResult);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("get-list-movie-titles")]
        public async Task<IActionResult> GetListOfMovieTitles(string searchQuery)
        {
            var result =
                await _movieFilterService.GetListOfMovieTitles(searchQuery);
            var response = _mapper.Map<SearchSuggestionResponse>(result);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("get-list-cinema-names")]
        public async Task<IActionResult> GetListOfCinemaNames(string searchQuery)
        {
            var result =
                await _movieFilterService.GetListOfCinemaNames(searchQuery);
            var response = _mapper.Map<SearchSuggestionResponse>(result);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("get-list-city-names")]
        public async Task<IActionResult> GetListOfCityNames(string searchQuery)
        {
            var result =
                await _movieFilterService.GetListOfCityNames(searchQuery);
            var response = _mapper.Map<SearchSuggestionResponse>(result);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}