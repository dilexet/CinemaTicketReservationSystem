using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CinemaTicketReservationSystem.DAL.Abstract
{
    public interface IUserManager<TUser> where TUser : class
    {
        Task<bool> CreateUserAsync(TUser user);
        Task<bool> UpdateUserAsync(TUser user);
        Task<bool> RemoveUserAsync(TUser user);

        Task<TUser> FindByUserIdAsync(Guid? userId);
        IQueryable<TUser> GetUsers(Expression<Func<TUser, bool>> predicate = null);
        Task<TUser> SingleOrDefaultAsync(Expression<Func<TUser, bool>> predicate = null);
        bool CheckPassword(string hashPassword, string password);
        String HasPasswordAsync(string password);
    }
}