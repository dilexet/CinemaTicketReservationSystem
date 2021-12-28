using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.WebApi.Models.Response.Cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class SeatTypeController : ControllerBase
    {
        private readonly ISeatTypeService _seatTypeService;
        private readonly IMapper _mapper;

        public SeatTypeController(ISeatTypeService seatTypeService, IMapper mapper)
        {
            _seatTypeService = seatTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeatTypes()
        {
            var seatTypesResult = await _seatTypeService.GetSeatTypes();
            var response = _mapper.Map<SeatTypeGetAllResponse>(seatTypesResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status404NotFound;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}