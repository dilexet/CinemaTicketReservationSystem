﻿using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.AuthModels;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Token;
using CinemaTicketReservationSystem.WebApi.Models.Response.Authorize;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorizeController> _logger;

        public AuthorizeController(
            IAuthorizeService authorizeService,
            IMapper mapper,
            ILogger<AuthorizeController> logger)
        {
            _authorizeService = authorizeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var result = await _authorizeService.LoginAsync(_mapper.Map<LoginModel>(userLoginRequest));

            var response = _mapper.Map<AuthorizeResponse>(result);

            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status401Unauthorized;
                return Unauthorized(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
        {
            var result = await _authorizeService.RegisterAsync(_mapper.Map<RegisterModel>(userRegisterRequest));

            var response = _mapper.Map<AuthorizeResponse>(result);

            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status401Unauthorized;
                return Unauthorized(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var result = await _authorizeService.RefreshTokenAsync(
                refreshTokenRequest.UserId,
                refreshTokenRequest.Token);

            var response = _mapper.Map<AuthorizeResponse>(result);

            if (!response.Success)
            {
                foreach (var error in response.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                response.Code = StatusCodes.Status401Unauthorized;
                return Unauthorized(response);
            }

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}