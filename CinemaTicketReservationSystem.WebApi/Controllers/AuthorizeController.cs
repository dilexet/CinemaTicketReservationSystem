using System;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract;
using CinemaTicketReservationSystem.BLL.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Results;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Token;
using CinemaTicketReservationSystem.WebApi.Models.Response;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly IValidator<UserLoginRequest> _loginValidator;
        private readonly IValidator<UserRegisterRequest> _registerValidator;
        private readonly IValidator<RefreshTokenRequest> _refreshTokenValidator;
        private readonly IMapper _mapper;

        public AuthorizeController(IAuthorizeService authorizeService, IMapper mapper, IValidator<UserLoginRequest> loginValidator, IValidator<UserRegisterRequest> registerValidator, IValidator<RefreshTokenRequest> refreshTokenValidator)
        {
            _authorizeService = authorizeService;
            _mapper = mapper;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
            _refreshTokenValidator = refreshTokenValidator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var validatorResult = await _loginValidator.ValidateAsync(userLoginRequest);
            if (!validatorResult.IsValid)
            {
                return BadRequest(new AuthorizeResponse()
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Errors = validatorResult.Errors
                });
            }

            AuthorizeResult result;
            try
            {
                result = await _authorizeService.LoginAsync(_mapper.Map<LoginModel>(userLoginRequest));
            }
            catch (Exception e)
            {
                return BadRequest(new AuthorizeResponse()
                {
                    Code = StatusCodes.Status500InternalServerError,
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
        {
            var validatorResult = await _registerValidator.ValidateAsync(userRegisterRequest);
            if (!validatorResult.IsValid)
            {
                return BadRequest(new AuthorizeResponse()
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Errors = validatorResult.Errors
                });
            }

            AuthorizeResult result;
            try
            {
                result = await _authorizeService.RegisterAsync(_mapper.Map<RegisterModel>(userRegisterRequest));
            }
            catch (Exception e)
            {
                return BadRequest(new AuthorizeResponse()
                {
                    Code = StatusCodes.Status500InternalServerError,
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
            var validatorResult = await _refreshTokenValidator.ValidateAsync(refreshTokenRequest);
            if (!validatorResult.IsValid)
            {
                return BadRequest(new AuthorizeResponse()
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Errors = validatorResult.Errors
                });
            }

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
                    Code = StatusCodes.Status500InternalServerError,
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