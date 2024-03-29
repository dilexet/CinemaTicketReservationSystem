﻿using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.WebApi.Models.Response.UserManagement;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IMapper _mapper;

        public UserManagementController(
            IUserManagementService userManagementService,
            IMapper mapper)
        {
            _userManagementService = userManagementService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromRoute] CreateUserRequestWrapper createUserRequestWrapper)
        {
            var usersResult =
                await _userManagementService.CreateUser(
                    _mapper.Map<UserModel>(createUserRequestWrapper.UserCreateRequest));
            var response = _mapper.Map<UserManagementResponse>(usersResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] UpdateUserRequestWrapper updateUserRequestWrapper)
        {
            var usersResult = await _userManagementService.UpdateUser(
                updateUserRequestWrapper.Id,
                _mapper.Map<UserModel>(updateUserRequestWrapper.UserUpdateRequest));
            var response = _mapper.Map<UserManagementResponse>(usersResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] UserRequestWrapper userRequestWrapper)
        {
            var usersResult = await _userManagementService.DeleteUser(userRequestWrapper.Id);
            var response = _mapper.Map<UserManagementRemoveResponse>(usersResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var usersResult = await _userManagementService.GetUsers();
            var response = _mapper.Map<UserManagementGetUsersResponse>(usersResult);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] UserRequestWrapper userRequestWrapper)
        {
            var usersResult = await _userManagementService.GetById(userRequestWrapper.Id);
            var response = _mapper.Map<UserManagementResponse>(usersResult);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}