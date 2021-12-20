using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CinemaTicketReservationSystem.DAL.Abstract
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<bool> CreateAsync(TEntity entity);

        Task<TEntity> FindByIdAsync(Guid? id);

        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<bool> Update(TEntity entity);

        Task<bool> Remove(TEntity entity);

        Task<bool> SaveAsync();
    }
}