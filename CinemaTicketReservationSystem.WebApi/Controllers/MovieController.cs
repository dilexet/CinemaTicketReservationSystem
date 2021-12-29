using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Filters;
using CinemaTicketReservationSystem.WebApi.Models.Filters;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Movie;
using CinemaTicketReservationSystem.WebApi.Models.Response.Movie;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper, IWebHostEnvironment environment)
        {
            _movieService = movieService;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromHeader] MovieRequest movieRequest, [FromForm] IFormFile file)
        {
            var uploadFileResult = await UploadFile(file);
            if (uploadFileResult == null)
            {
                return BadRequest(new MovieResponse()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Can not upload file"
                    }
                });
            }

            var movieModel = _mapper.Map<MovieModel>(movieRequest);
            movieModel.PosterUrl = uploadFileResult;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMovie(Guid id)
        {
            var movieResult = await _movieService.RemoveMovie(id);
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
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            var movieResult = await _movieService.GetMovieById(id);
            var response = _mapper.Map<MovieResponse>(movieResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
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
                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    var directory = "/Files/";
                    if (!Directory.Exists(_environment.WebRootPath + directory))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + directory);
                    }

                    var fileType = file.FileName.Split('.').Last();
                    var path = directory + Guid.NewGuid() + '.' + fileType;
                    using (FileStream fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return path;
                    }
                }
            }
            catch (IOException)
            {
                // TODO: logger
                return null;
            }

            return null;
        }
    }
}