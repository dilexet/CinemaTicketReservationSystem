using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Authorize
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _log;

        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> CreateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = await _context.Set<User>().AddAsync(user);
            if (result != null)
            {
                return await SaveAsync();
            }

            return false;
        }

        public async Task<User> FindByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            User user = null;
            try
            {
                user = await _context.Set<User>()
                    .Where(x => x.Id.Equals(id))
                    .Include(x => x.Role)
                    .Include(x => x.RefreshTokens)
                    .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return user;
        }

        public IQueryable<User> GetBy(Expression<Func<User, bool>> predicate = null)
        {
            IQueryable<User> users = null;
            try
            {
                users = predicate != null
                    ? _context.Set<User>().Where(predicate).Include(x => x.Role)
                    : _context.Set<User>().Include(x => x.Role);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return users;
        }

        public async Task<User> SingleOrDefaultAsync(Expression<Func<User, bool>> predicate = null)
        {
            User user = null;
            try
            {
                user = predicate != null
                    ? await _context.Set<User>().Where(predicate)
                        .Include(x => x.Role)
                        .Include(x => x.RefreshTokens)
                        .SingleOrDefaultAsync()
                    : await _context.Set<User>().Include(x => x.Role)
                        .Include(x => x.RefreshTokens).SingleOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return user;
        }

        public async Task<bool> Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                _context.Entry(user).State = EntityState.Modified;
                return await SaveAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
                return false;
            }
        }

        public async Task<bool> Remove(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                _context.Set<User>().Remove(user);
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

        public string HasPasswordAsync(string password)
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