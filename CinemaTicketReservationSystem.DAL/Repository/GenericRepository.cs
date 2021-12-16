using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CinemaTicketReservationSystem.DAL.Repository
{
    [SuppressMessage("ReSharper", "TemplateIsNotCompileTimeConstantProblem")]
    public class GenericRepository : IRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GenericRepository> _log;

        public GenericRepository(ApplicationDbContext context, ILogger<GenericRepository> log)
        {
            _context = context;
            _log = log;
        }

        public async Task<TEntity> FindByIdAsync<TEntity>(Guid? id) where TEntity : class
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            TEntity entity = null;
            try
            {
                entity = await _context.Set<TEntity>().FindAsync(id);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return entity;
        }

        public IQueryable<TEntity> GetBy<TEntity>(Expression<Func<TEntity, bool>> predicate = null)
            where TEntity : class
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
                _log.LogError(e.ToString());
            }

            return entities;
        }

        public async Task<TEntity> SingleOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
        {
            TEntity entity = null;
            try
            {
                entity = predicate != null
                    ? await _context.Set<TEntity>().Where(predicate).SingleOrDefaultAsync()
                    : await _context.Set<TEntity>().FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return entity;
        }

        public async Task<bool> CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                return true;
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
                return false;
            }
        }

        public bool Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
                return false;
            }
        }

        public bool Remove<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Set<TEntity>().Remove(entity);
                return true;
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