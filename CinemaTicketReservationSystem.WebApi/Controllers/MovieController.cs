using System;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.MovieModels;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Response.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
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
        public async Task<IActionResult> AddMovie(MovieRequest movieRequest)
        {
            var movieResult = await _movieService.AddMovie(_mapper.Map<MovieModel>(movieRequest));
            var response = _mapper.Map<MovieResponse>(movieResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovieInfo(Guid id, MovieRequest movieRequest)
        {
            var movieResult = await _movieService.UpdateMovieInfo(id, _mapper.Map<MovieModel>(movieRequest));
            var response = _mapper.Map<MovieResponse>(movieResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMovie()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok();
        }
    }
}