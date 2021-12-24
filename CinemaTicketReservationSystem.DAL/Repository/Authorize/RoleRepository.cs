using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Authorize;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Authorize
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RoleRepository> _log;

        public RoleRepository(ApplicationDbContext context, ILogger<RoleRepository> log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> CreateAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var result = await _context.Set<Role>().AddAsync(role);
            if (result != null)
            {
                return await SaveAsync();
            }

            return false;
        }

        public async Task<Role> FindByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Role role = null;
            try
            {
                role = await _context.Set<Role>()
                    .Where(x => x.Id.Equals(id))
                    .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return role;
        }

        public IQueryable<Role> GetBy(Expression<Func<Role, bool>> predicate = null)
        {
            IQueryable<Role> roles = null;
            try
            {
                roles = predicate != null
                    ? _context.Set<Role>().Where(predicate)
                    : _context.Set<Role>();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return roles;
        }

        public async Task<Role> FirstOrDefaultAsync(Expression<Func<Role, bool>> predicate = null)
        {
            Role role = null;
            try
            {
                role = predicate != null
                    ? await _context.Set<Role>().Where(predicate)
                        .FirstOrDefaultAsync()
                    : await _context.Set<Role>()
                        .OrderBy(x => x.Id)
                        .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return role;
        }

        public async Task<bool> UpdateAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            try
            {
                _context.Entry(role).State = EntityState.Modified;
                return await SaveAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
                return false;
            }
        }

        public async Task<bool> RemoveAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            try
            {
                _context.Set<Role>().Remove(role);
                return await SaveAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
                return false;
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
                return false;
            }
        }
    }
}