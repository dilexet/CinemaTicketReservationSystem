using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.DAL.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BasedEntity
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = await _context.Set<TEntity>().AddAsync(entity);
            if (result != null)
            {
                return await SaveAsync();
            }

            return false;
        }

        public virtual async Task<TEntity> FindByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            TEntity entity = await _context.Set<TEntity>()
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            return entity;
        }

        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> entities = predicate != null
                ? _context.Set<TEntity>().Where(predicate)
                : _context.Set<TEntity>();
            return entities;
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            TEntity entity = predicate != null
                ? await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync()
                : await _context.Set<TEntity>().OrderBy(x => x.Id).FirstOrDefaultAsync();

            return entity;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Entry(entity).State = EntityState.Modified;
            return await SaveAsync();
        }

        public virtual async Task<bool> RemoveAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<TEntity>().Remove(entity);
            return await SaveAsync();
        }

        public virtual async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}