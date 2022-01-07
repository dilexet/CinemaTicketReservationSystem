using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels;
using CinemaTicketReservationSystem.WebApi.Hubs;
using CinemaTicketReservationSystem.WebApi.Models.Response.Booking;
using CinemaTicketReservationSystem.WebApi.Models.Response.Session;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Booking;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IHubContext<SeatBookingHub> _hubContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingController> _logger;

        public BookingController(
            IBookingService bookingService,
            IMapper mapper,
            IHubContext<SeatBookingHub> hubContext,
            ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _hubContext = hubContext;
            _logger = logger;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> BookTickets([FromRoute] BookTicketsRequestWrapper bookTicketsRequestWrapper)
        {
            var bookingResult = await _bookingService.BookTickets(
                bookTicketsRequestWrapper.Id,
                _mapper.Map<BookingModel>(bookTicketsRequestWrapper.BookTicketsRequest));
            var response = _mapper.Map<BookTicketsResponse>(bookingResult);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            await _hubContext.Clients.All.SendAsync(
                "setBookingSeat",
                response.BookedOrderViewModel.ReservedSessionSeats.Select(x => x.Id));

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById([FromRoute] SessionRequestWrapper sessionRequestWrapper)
        {
            var sessionResult = await _bookingService.GetSessionById(sessionRequestWrapper.Id);
            var response = _mapper.Map<SessionResponse>(sessionResult);
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

        [HttpGet]
        public async Task<IActionResult> GetAvailableSessions()
        {
            var availableSessions = await _bookingService.GetAvailableSessions();
            var response = _mapper.Map<SessionGetAllResponse>(availableSessions);
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