using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Roles = "Admin")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagement _userManagement;
        private readonly IMapper _mapper;

        public UserManagementController(IUserManagement userManagement, IMapper mapper)
        {
            _userManagement = userManagement;
            _mapper = mapper;
        }

        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManagement.GetUsers();
            if (users == null)
            {
                return BadRequest();
            }

            var usersView = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return Ok(usersView);
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(UserCreateRequest userCreateRequest)
        {
            var user = await _userManagement.CreateUser(_mapper.Map<UserModel>(userCreateRequest));
            if (user == null)
            {
                return BadRequest();
            }

            var userView = _mapper.Map<UserViewModel>(user);
            return Ok(userView);
        }

        [HttpPut("create-user")]
        public async Task<IActionResult> UpdateUser()
        {
            await _userManagement.GetUsers();
            return Ok();
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser()
        {
            await _userManagement.GetUsers();
            return Ok();
        }
    }
}