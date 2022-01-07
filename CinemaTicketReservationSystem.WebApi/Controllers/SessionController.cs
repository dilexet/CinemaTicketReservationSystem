using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Session;
using CinemaTicketReservationSystem.WebApi.Models.Response.Session;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;
        private readonly ILogger<SessionController> _logger;

        public SessionController(ISessionService sessionService, IMapper mapper, ILogger<SessionController> logger)
        {
            _sessionService = sessionService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddSession(SessionRequest sessionRequest)
        {
            var result = await _sessionService.AddSession(_mapper.Map<SessionRequestModel>(sessionRequest));
            var response = _mapper.Map<SessionResponse>(result);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSessionInfo(
            [FromRoute] UpdateSessionRequestWrapper updateSessionRequestWrapper)
        {
            var result = await _sessionService.UpdateSessionInfo(
                updateSessionRequestWrapper.Id,
                _mapper.Map<SessionRequestModel>(updateSessionRequestWrapper.SessionRequest));
            var response = _mapper.Map<SessionResponse>(result);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSession([FromRoute] SessionRequestWrapper sessionRequestWrapper)
        {
            var result = await _sessionService.RemoveSession(sessionRequestWrapper.Id);
            var response = _mapper.Map<SessionRemoveResponse>(result);
            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById([FromRoute] SessionRequestWrapper sessionRequestWrapper)
        {
            var result = await _sessionService.GetSessionById(sessionRequestWrapper.Id);
            var response = _mapper.Map<SessionResponse>(result);
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
        public async Task<IActionResult> GetSessions()
        {
            var result = await _sessionService.GetSessions();
            var response = _mapper.Map<SessionGetAllResponse>(result);
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