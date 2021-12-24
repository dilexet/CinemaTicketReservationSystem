using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Session;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Session
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SessionRepository> _log;

        public SessionRepository(ApplicationDbContext context, ILogger<SessionRepository> log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> CreateAsync(Entity.SessionEntity.Session entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = await _context.Set<Entity.SessionEntity.Session>().AddAsync(entity);
            if (result != null)
            {
                return await SaveAsync();
            }

            return false;
        }

        public async Task<Entity.SessionEntity.Session> FindByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Entity.SessionEntity.Session session = null;
            try
            {
                session = await _context.Set<Entity.SessionEntity.Session>()
                    .Where(x => x.Id.Equals(id))
                    .Include(x => x.Movie)
                    .Include(x => x.Hall)
                    .Include(x => x.Cinema)
                    .Include(x => x.SessionSeatTypes)
                    .Include(x => x.SessionAdditionalServices)
                    .Include(x => x.Tickets)
                    .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return session;
        }

        public IQueryable<Entity.SessionEntity.Session> GetBy(
            Expression<Func<Entity.SessionEntity.Session, bool>> predicate = null)
        {
            IQueryable<Entity.SessionEntity.Session> sessions = null;
            try
            {
                sessions = predicate != null
                    ? _context.Set<Entity.SessionEntity.Session>()
                        .Where(predicate)
                        .Include(x => x.Movie)
                        .Include(x => x.Hall)
                        .Include(x => x.Cinema)
                        .Include(x => x.SessionSeatTypes)
                        .Include(x => x.SessionAdditionalServices)
                        .Include(x => x.Tickets)
                    : _context.Set<Entity.SessionEntity.Session>()
                        .Include(x => x.Movie)
                        .Include(x => x.Hall)
                        .Include(x => x.Cinema)
                        .Include(x => x.SessionSeatTypes)
                        .Include(x => x.SessionAdditionalServices)
                        .Include(x => x.Tickets);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return sessions;
        }

        public async Task<Entity.SessionEntity.Session> FirstOrDefaultAsync(
            Expression<Func<Entity.SessionEntity.Session, bool>> predicate = null)
        {
            Entity.SessionEntity.Session session = null;
            try
            {
                session = predicate != null
                    ? await _context.Set<Entity.SessionEntity.Session>().Where(predicate)
                        .Include(x => x.Movie)
                        .Include(x => x.Hall)
                        .Include(x => x.Cinema)
                        .Include(x => x.SessionSeatTypes)
                        .Include(x => x.SessionAdditionalServices)
                        .Include(x => x.Tickets)
                        .FirstOrDefaultAsync()
                    : await _context.Set<Entity.SessionEntity.Session>()
                        .Include(x => x.Movie)
                        .Include(x => x.Hall)
                        .Include(x => x.Cinema)
                        .Include(x => x.SessionSeatTypes)
                        .Include(x => x.SessionAdditionalServices)
                        .Include(x => x.Tickets)
                        .OrderBy(x => x.Id).FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return session;
        }

        public async Task<bool> UpdateAsync(Entity.SessionEntity.Session entity)
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

        public async Task<bool> RemoveAsync(Entity.SessionEntity.Session entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Set<Entity.SessionEntity.Session>().Remove(entity);
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