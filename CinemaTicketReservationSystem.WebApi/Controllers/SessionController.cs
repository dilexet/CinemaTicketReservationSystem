using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Session;
using CinemaTicketReservationSystem.WebApi.Models.Response.Session;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ManagerRole")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddSession(SessionRequest sessionRequest)
        {
            var result = await _sessionService.AddSession(_mapper.Map<SessionRequestModel>(sessionRequest));
            var response = _mapper.Map<SessionResponse>(result);
            if (!response.Success)
            {
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
                response.Code = StatusCodes.Status404NotFound;
                return NotFound(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}