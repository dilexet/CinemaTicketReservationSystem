using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Cinema;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Cinema
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CinemaRepository> _log;

        public CinemaRepository(ApplicationDbContext context, ILogger<CinemaRepository> log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> CreateAsync(Entity.CinemaEntity.Cinema entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = await _context.Set<Entity.CinemaEntity.Cinema>().AddAsync(entity);
            if (result != null)
            {
                return await SaveAsync();
            }

            return false;
        }

        public async Task<Entity.CinemaEntity.Cinema> FindByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Entity.CinemaEntity.Cinema cinema = null;
            try
            {
                cinema = await _context.Set<Entity.CinemaEntity.Cinema>()
                    .Where(x => x.Id.Equals(id))
                    .Include(x => x.Sessions)
                    .Include(x => x.Halls)
                    .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return cinema;
        }

        public IQueryable<Entity.CinemaEntity.Cinema> GetBy(
            Expression<Func<Entity.CinemaEntity.Cinema, bool>> predicate = null)
        {
            IQueryable<Entity.CinemaEntity.Cinema> cinemas = null;
            try
            {
                cinemas = predicate != null
                    ? _context.Set<Entity.CinemaEntity.Cinema>()
                        .Where(predicate)
                        .Include(x => x.Sessions)
                        .Include(x => x.Halls)
                    : _context.Set<Entity.CinemaEntity.Cinema>()
                        .Include(x => x.Sessions)
                        .Include(x => x.Halls);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return cinemas;
        }

        public async Task<Entity.CinemaEntity.Cinema> FirstOrDefaultAsync(
            Expression<Func<Entity.CinemaEntity.Cinema, bool>> predicate = null)
        {
            Entity.CinemaEntity.Cinema cinema = null;
            try
            {
                cinema = predicate != null
                    ? await _context.Set<Entity.CinemaEntity.Cinema>().Where(predicate)
                        .Include(x => x.Sessions)
                        .Include(x => x.Halls)
                        .FirstOrDefaultAsync()
                    : await _context.Set<Entity.CinemaEntity.Cinema>()
                        .Include(x => x.Sessions)
                        .Include(x => x.Halls)
                        .OrderBy(x => x.Id).FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return cinema;
        }

        public async Task<bool> UpdateAsync(Entity.CinemaEntity.Cinema entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return await SaveAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
                return false;
            }
        }

        public async Task<bool> RemoveAsync(Entity.CinemaEntity.Cinema entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Set<Entity.CinemaEntity.Cinema>().Remove(entity);
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