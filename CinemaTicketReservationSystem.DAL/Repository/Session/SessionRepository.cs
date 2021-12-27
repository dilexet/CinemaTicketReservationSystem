using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Session;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Session
{
    public class SessionRepository : BaseRepository<Entity.SessionEntity.Session>, ISessionRepository
    {
        private readonly ILogger<SessionRepository> _log;

        public SessionRepository(ApplicationDbContext context, ILogger<SessionRepository> log)
            : base(context)
        {
            _log = log;
        }

        public override async Task<bool> CreateAsync(Entity.SessionEntity.Session session)
        {
            try
            {
                return await base.CreateAsync(session);
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

        public override async Task<Entity.SessionEntity.Session> FindByIdAsync(Guid? id)
        {
            Entity.SessionEntity.Session session = null;
            try
            {
                session = await base.FindByIdAsync(id);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return session;
        }

        public override IQueryable<Entity.SessionEntity.Session> GetBy(
            Expression<Func<Entity.SessionEntity.Session, bool>> predicate = null)
        {
            IQueryable<Entity.SessionEntity.Session> sessions = null;
            try
            {
                sessions = base.GetBy(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return sessions;
        }

        public override async Task<Entity.SessionEntity.Session> FirstOrDefaultAsync(
            Expression<Func<Entity.SessionEntity.Session, bool>> predicate = null)
        {
            Entity.SessionEntity.Session session = null;
            try
            {
                session = await base.FirstOrDefaultAsync(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return session;
        }

        public override async Task<bool> UpdateAsync(Entity.SessionEntity.Session session)
        {
            try
            {
                return await base.UpdateAsync(session);
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

        public override async Task<bool> RemoveAsync(Entity.SessionEntity.Session session)
        {
            try
            {
                return await base.RemoveAsync(session);
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
    }
}