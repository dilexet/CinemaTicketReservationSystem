﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Filters;
using CinemaTicketReservationSystem.WebApi.Models.Filters;
using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using CinemaTicketReservationSystem.WebApi.Models.Response.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    // [Authorize(Policy = "AdminRole")]
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

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateRequest userCreateRequest)
        {
            var usersResult = await _userManagement.CreateUser(_mapper.Map<UserModel>(userCreateRequest));
            var response = _mapper.Map<UserManagementResponse>(usersResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(Guid id, UserUpdateRequest userUpdateRequest)
        {
            var usersResult = await _userManagement.UpdateUser(id, _mapper.Map<UserModel>(userUpdateRequest));
            var response = _mapper.Map<UserManagementResponse>(usersResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var usersResult = await _userManagement.DeleteUser(id);
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
        public async Task<IActionResult> GetUsers([FromQuery] FilterParameters filter)
        {
            var usersResult = await _userManagement.GetUsers(_mapper.Map<FilterParametersModel>(filter));
            var response = _mapper.Map<UserManagementGetUsersResponse>(usersResult);
            if (!response.Success)
            {
                response.Code = StatusCodes.Status404NotFound;
                return BadRequest(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var usersResult = await _userManagement.GetById(id);
            var response = _mapper.Map<UserManagementResponse>(usersResult);
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