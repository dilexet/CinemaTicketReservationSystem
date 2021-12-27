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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ILogger<UserRepository> _log;

        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> log)
            : base(context)
        {
            _log = log;
        }

        public override async Task<bool> CreateAsync(User user)
        {
            try
            {
                return await base.CreateAsync(user);
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

        public override async Task<User> FindByIdAsync(Guid? id)
        {
            User user = null;
            try
            {
                user = await base.FindByIdAsync(id);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return user;
        }

        public override IQueryable<User> GetBy(Expression<Func<User, bool>> predicate = null)
        {
            IQueryable<User> users = null;
            try
            {
                users = base.GetBy(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return users;
        }

        public override async Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> predicate = null)
        {
            User user = null;
            try
            {
                user = await base.FirstOrDefaultAsync(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return user;
        }

        public override async Task<bool> UpdateAsync(User user)
        {
            try
            {
                return await base.UpdateAsync(user);
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

        public override async Task<bool> RemoveAsync(User user)
        {
            try
            {
                return await base.RemoveAsync(user);
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

        public bool CheckPassword(string hashPassword, string password)
        {
            if (string.IsNullOrEmpty(hashPassword))
            {
                throw new ArgumentNullException(nameof(hashPassword));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var result = BCrypt.Net.BCrypt.Verify(password, hashPassword);
            return result;
        }

        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashPassword;
        }
    }
}