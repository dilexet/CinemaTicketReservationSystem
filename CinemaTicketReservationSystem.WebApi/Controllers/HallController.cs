using System;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.HallModels;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.Response.Hall;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IHallService _hallService;
        private readonly IMapper _mapper;

        public HallController(IHallService hallService, IMapper mapper)
        {
            _hallService = hallService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddHall(
            Guid cinemaId, HallRequest hallRequest)
        {
            var hallResult = await _hallService.AddHall(
                cinemaId,
                _mapper.Map<HallModel>(hallRequest));

            var response = _mapper.Map<HallResponse>(hallResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHall(Guid id, HallRequest hallRequest)
        {
            var hallResult = await _hallService.UpdateHall(
                id,
                _mapper.Map<HallModel>(hallRequest));

            var response = _mapper.Map<HallResponse>(hallResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveHall(Guid id)
        {
            var hallResult = await _hallService.RemoveHall(id);
            var response = _mapper.Map<HallRemoveResponse>(hallResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHallById(Guid id)
        {
            var hallResult = await _hallService.GetHallById(id);
            var response = _mapper.Map<HallResponse>(hallResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetHalls()
        {
            var hallResult = await _hallService.GetHalls();
            var response = _mapper.Map<HallGetAllResponse>(hallResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}