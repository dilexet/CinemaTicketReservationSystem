using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.DAL.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BasedEntity
    {
        private readonly ILogger<BaseRepository<TEntity>> _log;
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context, ILogger<BaseRepository<TEntity>> log)
        {
            _context = context;
            _log = log;
        }

        public virtual async Task<bool> CreateAsync(TEntity entity)
        {
            EntityEntry<TEntity> result = null;
            try
            {
                result = await _context.Set<TEntity>().AddAsync(entity);
            }
            catch (SqlException e)
            {
                _log.LogError(e, "Error while creating model");
            }

            if (result != null)
            {
                return await SaveAsync();
            }

            return false;
        }

        public virtual async Task<TEntity> FindByIdAsync(Guid? id)
        {
            TEntity entity = null;
            try
            {
                entity = await _context.Set<TEntity>()
                    .Where(x => x.Id.Equals(id))
                    .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e, "Error while finding model by id");
            }

            return entity;
        }

        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> entities = null;
            try
            {
                entities = predicate != null
                    ? _context.Set<TEntity>().Where(predicate)
                    : _context.Set<TEntity>();
            }
            catch (SqlException e)
            {
                _log.LogError(e, "Error while getting models by predicate");
            }

            return entities;
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            TEntity entity = null;
            try
            {
                entity = predicate != null
                    ? await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync()
                    : await _context.Set<TEntity>().OrderBy(x => x.Id).FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e, "Error while getting model by predicate or default");
            }

            return entity;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return await SaveAsync();
            }
            catch (DbUpdateException e)
            {
                _log.LogError(e, "Error while updating model");
                return false;
            }
        }

        public virtual bool Remove(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
            }
            catch (SqlException e)
            {
                _log.LogError(e, "Error while removing model");
                return false;
            }

            return true;
        }

        public virtual async Task<bool> RemoveAndSaveAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
            }
            catch (SqlException e)
            {
                _log.LogError(e, "Error while removing model");
            }

            return await SaveAsync();
        }

        public virtual async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (SqlException e)
            {
                _log.LogError(e, "Error while saving model");
                return false;
            }
        }
    }
}