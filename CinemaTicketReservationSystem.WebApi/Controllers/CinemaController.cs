using System;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.CinemaModels;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.Response.Cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMapper _mapper;

        public CinemaController(ICinemaService cinemaService, IMapper mapper)
        {
            _cinemaService = cinemaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCinema(CinemaRequest cinemaRequest)
        {
            var cinemaResult = await _cinemaService.AddCinema(_mapper.Map<CinemaModel>(cinemaRequest));
            var response = _mapper.Map<CinemaResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCinemaInfo(Guid id, CinemaRequest cinemaRequest)
        {
            var cinemaResult = await _cinemaService.UpdateCinemaInfo(id, _mapper.Map<CinemaModel>(cinemaRequest));
            var response = _mapper.Map<CinemaResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCinema(Guid id)
        {
            var cinemaResult = await _cinemaService.RemoveCinema(id);
            var response = _mapper.Map<CinemaRemoveResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCinemaById(Guid id)
        {
            var cinemaResult = await _cinemaService.GetCinemaById(id);
            var response = _mapper.Map<CinemaResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status404NotFound;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCinemas()
        {
            var cinemaResult = await _cinemaService.GetCinemas();
            var response = _mapper.Map<CinemaGetAllResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status404NotFound;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("add-additional-service")]
        public async Task<IActionResult> AddAdditionalService(
            Guid cinemaId, AdditionalServiceRequest additionalServiceRequest)
        {
            var cinemaResult = await _cinemaService.AddAdditionalService(
                cinemaId,
                _mapper.Map<AdditionalServiceModel>(additionalServiceRequest));

            var response = _mapper.Map<CinemaResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("add-hall")]
        public async Task<IActionResult> AddHall(
            Guid cinemaId, HallRequest hallRequest)
        {
            var cinemaResult = await _cinemaService.AddHall(
                cinemaId,
                _mapper.Map<HallModel>(hallRequest));

            var response = _mapper.Map<CinemaResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("update-additional-service")]
        public async Task<IActionResult> UpdateAdditionalService(
            Guid id, Guid cinemaId, AdditionalServiceRequest additionalServiceRequest)
        {
            var cinemaResult = await _cinemaService.UpdateAdditionalService(
                id,
                cinemaId,
                _mapper.Map<AdditionalServiceModel>(additionalServiceRequest));

            var response = _mapper.Map<CinemaResponse>(cinemaResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("update-hall")]
        public async Task<IActionResult> UpdateHall(
            Guid id, Guid cinemaId, HallRequest hallRequest)
        {
            var cinemaResult = await _cinemaService.UpdateHall(
                id,
                cinemaId,
                _mapper.Map<HallModel>(hallRequest));

            var response = _mapper.Map<CinemaResponse>(cinemaResult);
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