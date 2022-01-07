using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.WebApi.Models.Response.Cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class SeatTypeController : ControllerBase
    {
        private readonly ISeatTypeService _seatTypeService;
        private readonly IMapper _mapper;
        private readonly ILogger<SeatTypeController> _logger;

        public SeatTypeController(ISeatTypeService seatTypeService, IMapper mapper, ILogger<SeatTypeController> logger)
        {
            _seatTypeService = seatTypeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetSeatTypes()
        {
            var seatTypesResult = _seatTypeService.GetSeatTypes();
            var response = _mapper.Map<SeatTypeGetAllResponse>(seatTypesResult);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}