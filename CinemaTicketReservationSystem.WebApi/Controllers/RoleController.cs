using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.WebApi.Models.Response.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminRole")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleServiceService;
        private readonly IMapper _mapper;

        public RoleController(
            IRoleService roleServiceService,
            IMapper mapper)
        {
            _roleServiceService = roleServiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var rolesResult = await _roleServiceService.GetRoles();
            var response = _mapper.Map<RoleManagementGetRolesResponse>(rolesResult);

            response.Code = StatusCodes.Status200OK;
            return Ok(response);
        }
    }
}