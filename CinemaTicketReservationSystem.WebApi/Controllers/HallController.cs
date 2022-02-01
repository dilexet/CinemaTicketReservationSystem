using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.HallModels;
using CinemaTicketReservationSystem.WebApi.Models.Response.Hall;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Hall;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ManagerRole")]
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

        [HttpPost("{cinemaId}")]
        public async Task<IActionResult> AddHall([FromRoute] AddHallRequestWrapper addHallRequestWrapper)
        {
            var hallResult = await _hallService.AddHall(
                addHallRequestWrapper.CinemaId,
                _mapper.Map<HallModel>(addHallRequestWrapper.HallRequest));

            var response = _mapper.Map<HallResponse>(hallResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("{id}/{cinemaId}")]
        public async Task<IActionResult> UpdateHall([FromRoute] UpdateHallRequestWrapper updateHallRequestWrapper)
        {
            var hallResult = await _hallService.UpdateHall(
                updateHallRequestWrapper.Id,
                _mapper.Map<HallModel>(updateHallRequestWrapper.HallRequest));

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
        public async Task<IActionResult> RemoveHall([FromRoute] HallRequestWrapper hallRequestWrapper)
        {
            var hallResult = await _hallService.RemoveHall(hallRequestWrapper.Id);
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
        public async Task<IActionResult> GetHallById([FromRoute] HallRequestWrapper hallRequestWrapper)
        {
            var hallResult = await _hallService.GetHallById(hallRequestWrapper.Id);
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

        [HttpGet("{id}/cinema")]
        public async Task<IActionResult> GetHallsByCinemaId([FromRoute] CinemaRequestWrapper cinemaRequestWrapper)
        {
            var hallResult = await _hallService.GetHallsByCinemaId(cinemaRequestWrapper.Id);
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