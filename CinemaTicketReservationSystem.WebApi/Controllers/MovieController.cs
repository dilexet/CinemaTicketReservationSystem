using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.WebApi.Models.Filters;
using CinemaTicketReservationSystem.WebApi.Models.Response.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ManagerRole")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromRoute] AddMovieRequestWrapper addMovieRequestWrapper)
        {
            var movieModel = _mapper.Map<MovieModel>(addMovieRequestWrapper.MovieRequest);
            var movieResult = await _movieService.AddMovie(movieModel);
            var response = _mapper.Map<MovieResponse>(movieResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieInfo(
            [FromRoute] UpdateMovieRequestWrapper updateMovieRequestWrapper)
        {
            var movieResult = await _movieService.UpdateMovieInfo(
                updateMovieRequestWrapper.Id,
                _mapper.Map<MovieModel>(updateMovieRequestWrapper.MovieRequest));
            var response = _mapper.Map<MovieResponse>(movieResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMovie([FromRoute] MovieRequestWrapper movieRequestWrapper)
        {
            var movieResult = await _movieService.RemoveMovie(movieRequestWrapper.Id);
            var response = _mapper.Map<MovieRemoveResponse>(movieResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById([FromRoute] MovieRequestWrapper movieRequestWrapper)
        {
            var movieResult = await _movieService.GetMovieById(movieRequestWrapper.Id);
            var response = _mapper.Map<MovieResponse>(movieResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies([FromQuery] FilterParameters filter)
        {
            var movieResult = await _movieService.GetMovies(_mapper.Map<FilterParametersModel>(filter));
            var response = _mapper.Map<MovieGetAllResponse>(movieResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}