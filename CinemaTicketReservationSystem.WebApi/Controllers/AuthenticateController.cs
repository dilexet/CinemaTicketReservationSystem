using System;
using System.Linq;
using System.Security.Claims;
using CinemaTicketReservationSystem.WebApi.Jwt;
using CinemaTicketReservationSystem.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IdentityService _identityService;
        private readonly IOptions<CinemaTicketReservationSystem.WebApi.Cookie.CookieOptions> _cookieOptions;

        public AuthenticateController(JwtService jwtService, IdentityService identityService,
            IOptions<CinemaTicketReservationSystem.WebApi.Cookie.CookieOptions> cookieOptions)
        {
            _jwtService = jwtService;
            _identityService = identityService;
            _cookieOptions = cookieOptions;
        }

        [HttpPost("create-jwt")]
        public IActionResult CreateJwt(UserViewModel userViewModel)
        {
            if (userViewModel.Equals(null))
            {
                return BadRequest();
            }

            var token = _jwtService.Generate(
                _identityService.CreateClaimsIdentity(userViewModel.Name, userViewModel.Role));

            // TODO: ERROR - _cookieOptions.Value is null
            string name = _cookieOptions.Value.Name;
            int lifeTime = Convert.ToInt32(_cookieOptions.Value.LifeTime);

            if (String.IsNullOrEmpty(name) || lifeTime.Equals(0))
            {
                return BadRequest();
            }
            
            HttpContext.Response.Cookies.Append(name, token ?? string.Empty,
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTime.Today.AddDays(lifeTime),
                }
            );

            return Ok(token);
        }

        [HttpGet("token_verify")]
        public IActionResult TokenVerify()
        {
            var jwt = Request.Cookies[_cookieOptions.Value.Name];

            if (String.IsNullOrEmpty(jwt))
            {
                return Unauthorized();
            }

            var validatedToken = _jwtService.Verify(jwt);
            if (validatedToken.Equals(null))
            {
                return Unauthorized();
            }

            var claims = validatedToken.Claims.ToList();


            var name = claims
                .Where(x => x.Type == ClaimTypes.Name)
                .Select(x => x.Value).SingleOrDefault();

            var role = claims
                .Where(x => x.Type == ClaimTypes.Role)
                .Select(x => x.Value).SingleOrDefault();

            UserViewModel user = new UserViewModel
            {
                Name = name,
                Role = role
            };
            return Ok(user);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            var jwt = HttpContext.Request.Cookies[_cookieOptions.Value.Name];
            if (jwt == null)
            {
                return Unauthorized();
            }
            
            HttpContext.Response.Cookies.Append(_cookieOptions.Value.Name, jwt, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.Now.AddYears(-1),
            });
            
            return Ok();
        }
    }
}