using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Role;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRepository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleServiceGetRolesResult> GetRoles()
        {
            var roles = _roleRepository.GetBy();

            var roleModels = _mapper.Map<IEnumerable<RoleModel>>(await roles.ToListAsync());

            return new RoleServiceGetRolesResult()
            {
                Success = true,
                RoleModels = roleModels
            };
        }
    }
}