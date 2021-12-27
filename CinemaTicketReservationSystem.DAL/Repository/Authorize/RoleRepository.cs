using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Authorize;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Authorize
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly ILogger<RoleRepository> _log;

        public RoleRepository(ApplicationDbContext context, ILogger<RoleRepository> log)
            : base(context)
        {
            _log = log;
        }

        public override async Task<bool> CreateAsync(Role role)
        {
            try
            {
                return await base.CreateAsync(role);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return false;
        }

        public override async Task<Role> FindByIdAsync(Guid? id)
        {
            Role role = null;
            try
            {
                role = await base.FindByIdAsync(id);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return role;
        }

        public override IQueryable<Role> GetBy(Expression<Func<Role, bool>> predicate = null)
        {
            IQueryable<Role> roles = null;
            try
            {
                roles = base.GetBy(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return roles;
        }

        public override async Task<Role> FirstOrDefaultAsync(Expression<Func<Role, bool>> predicate = null)
        {
            Role role = null;
            try
            {
                role = await base.FirstOrDefaultAsync(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return role;
        }

        public override async Task<bool> UpdateAsync(Role role)
        {
            try
            {
                return await base.UpdateAsync(role);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return false;
        }

        public override async Task<bool> RemoveAsync(Role role)
        {
            try
            {
                return await base.RemoveAsync(role);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return false;
        }

        public override async Task<bool> SaveAsync()
        {
            try
            {
                return await base.SaveAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
                return false;
            }
        }
    }
}