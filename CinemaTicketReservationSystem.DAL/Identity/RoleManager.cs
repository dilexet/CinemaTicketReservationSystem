using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity;

namespace CinemaTicketReservationSystem.DAL.Identity
{
    public class RoleManager : IRoleManager<Role>
    {
        private readonly IRepository _repository;

        public RoleManager(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateRoleAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var result = await _repository.CreateAsync(role);
            if (result)
            {
                return await _repository.SaveAsync();
            }

            return false;
        }

        public async Task<bool> UpdateRoleAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var result = _repository.Update(role);
            if (result)
            {
                return await _repository.SaveAsync();
            }

            return false;
        }

        public async Task<bool> RemoveRoleAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var result = _repository.Remove(role);
            if (result)
            {
                return await _repository.SaveAsync();
            }

            return false;
        }

        public async Task<Role> FindByRoleIdAsync(Guid? roleId)
        {
            if (roleId == null)
            {
                throw new ArgumentNullException(nameof(roleId));
            }

            var role = await _repository.FindByIdAsync<Role>(roleId);
            return role;
        }

        public IQueryable<Role> GetRoles(Expression<Func<Role, bool>> predicate = null)
        {
            var roles = _repository.GetBy(predicate);
            return roles;
        }

        public async Task<Role> SingleOrDefaultAsync(Expression<Func<Role, bool>> predicate = null)
        {
            var role = await _repository.SingleOrDefaultAsync(predicate);
            return role;
        }
    }
}