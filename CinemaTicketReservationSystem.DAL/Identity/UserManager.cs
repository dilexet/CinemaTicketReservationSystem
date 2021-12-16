using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity;

namespace CinemaTicketReservationSystem.DAL.Identity
{
    public class UserManager : IUserManager<User>
    {
        private readonly IRepository _repository;

        public UserManager(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = await _repository.CreateAsync(user);
            if (result)
            {
                return await _repository.SaveAsync();
            }

            return false;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = _repository.Update(user);
            if (result)
            {
                return await _repository.SaveAsync();
            }

            return false;
        }

        public async Task<bool> RemoveUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = _repository.Remove(user);
            if (result)
            {
                return await _repository.SaveAsync();
            }

            return false;
        }

        public async Task<User> FindByUserIdAsync(Guid? userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var user = await _repository.FindByIdAsync<User>(userId);
            return user;
        }

        public IQueryable<User> GetUsers(Expression<Func<User, bool>> predicate = null)
        {
            var users = _repository.GetBy(predicate);
            return users;
        }

        public async Task<User> SingleOrDefaultAsync(Expression<Func<User, bool>> predicate = null)
        {
            var user = await _repository.SingleOrDefaultAsync(predicate);
            return user;
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

            // TODO: SOLID ????
            var result = BCrypt.Net.BCrypt.Verify(hashPassword, password);
            return result;
        }

        public String HasPasswordAsync(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            // TODO: SOLID ????
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashPassword;
        }
    }
}