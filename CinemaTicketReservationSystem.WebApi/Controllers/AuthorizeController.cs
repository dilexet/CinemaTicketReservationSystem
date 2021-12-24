﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Results.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Token;
using CinemaTicketReservationSystem.WebApi.Models.Response.Authorize;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly IMapper _mapper;

        public AuthorizeController(IAuthorizeService authorizeService, IMapper mapper)
        {
            _authorizeService = authorizeService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
           AuthorizeResult result;
           try
           {
               result = await _authorizeService.LoginAsync(_mapper.Map<LoginModel>(userLoginRequest));
           }
           catch (Exception e)
           {
               return BadRequest(new AuthorizeResponse()
               {
                   Code = StatusCodes.Status400BadRequest,
                   Success = false,
                   Errors = new[] { e.Message }
               });
           }

           var response = _mapper.Map<AuthorizeResponse>(result);

           if (response.Success)
           {
               response.Code = StatusCodes.Status200OK;
               return Ok(response);
           }

           response.Code = StatusCodes.Status401Unauthorized;
           return Unauthorized(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
        {
            AuthorizeResult result;
            try
            {
                result = await _authorizeService.RegisterAsync(_mapper.Map<RegisterModel>(userRegisterRequest));
            }
            catch (Exception e)
            {
                return BadRequest(new AuthorizeResponse()
                {
                    Code = StatusCodes.Status400BadRequest,
                    Success = false,
                    Errors = new[] { e.Message }
                });
            }

            AuthorizeResponse response = _mapper.Map<AuthorizeResponse>(result);

            if (response.Success)
            {
                response.Code = StatusCodes.Status200OK;
                return Ok(response);
            }

            response.Code = StatusCodes.Status401Unauthorized;
            return Unauthorized(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            AuthorizeResult result;
            try
            {
                result = await _authorizeService.RefreshTokenAsync(
                    refreshTokenRequest.Username,
                    refreshTokenRequest.Token);
            }
            catch (Exception e)
            {
                return BadRequest(new AuthorizeResponse()
                {
                    Code = StatusCodes.Status400BadRequest,
                    Success = false,
                    Errors = new[] { e.Message }
                });
            }

            AuthorizeResponse response = _mapper.Map<AuthorizeResponse>(result);

            if (response.Success)
            {
                response.Code = StatusCodes.Status200OK;
                return Ok(response);
            }

            response.Code = StatusCodes.Status401Unauthorized;
            return Unauthorized(response);
        }
    }
}