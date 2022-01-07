using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.WebApi.Models.Response.UserProfile;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "UserRole")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserProfileController> _logger;

        public UserProfileController(
            IUserProfileService userProfileService,
            IMapper mapper,
            ILogger<UserProfileController> logger)
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProfile(
            [FromRoute] UserProfileUpdateRequestWrapper userProfileUpdateRequestWrapper)
        {
            var usersResult =
                await _userProfileService.UpdateUserProfile(
                    userProfileUpdateRequestWrapper.Id,
                    _mapper.Map<UserProfileModel>(userProfileUpdateRequestWrapper.UserProfileUpdateRequest));
            var response = _mapper.Map<UserProfileResponse>(usersResult);
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
        public async Task<IActionResult> GetById([FromRoute] UserProfileGetRequestWrapper userProfileGetRequestWrapper)
        {
            var usersResult =
                await _userProfileService.GetUserProfileById(
                    userProfileGetRequestWrapper.Id,
                    userProfileGetRequestWrapper.ShowPastTicket);
            var response = _mapper.Map<UserProfileResponse>(usersResult);
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