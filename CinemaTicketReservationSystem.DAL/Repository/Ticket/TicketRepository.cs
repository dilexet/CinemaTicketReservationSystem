using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Ticket;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Ticket
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TicketRepository> _log;

        public TicketRepository(ApplicationDbContext context, ILogger<TicketRepository> log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> CreateAsync(Entity.TicketEntity.Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = await _context.Set<Entity.TicketEntity.Ticket>().AddAsync(entity);
            if (result != null)
            {
                return await SaveAsync();
            }

            return false;
        }

        public async Task<Entity.TicketEntity.Ticket> FindByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Entity.TicketEntity.Ticket ticket = null;
            try
            {
                ticket = await _context.Set<Entity.TicketEntity.Ticket>()
                    .Where(x => x.Id.Equals(id))
                    .Include(x => x.Session)
                    .Include(x => x.Seat)
                    .Include(x => x.AdditionalServices)
                    .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return ticket;
        }

        public IQueryable<Entity.TicketEntity.Ticket> GetBy(
            Expression<Func<Entity.TicketEntity.Ticket, bool>> predicate = null)
        {
            IQueryable<Entity.TicketEntity.Ticket> tickets = null;
            try
            {
                tickets = predicate != null
                    ? _context.Set<Entity.TicketEntity.Ticket>()
                        .Where(predicate)
                        .Include(x => x.Session)
                        .Include(x => x.Seat)
                        .Include(x => x.AdditionalServices)
                    : _context.Set<Entity.TicketEntity.Ticket>()
                        .Include(x => x.Session)
                        .Include(x => x.Seat)
                        .Include(x => x.AdditionalServices);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return tickets;
        }

        public async Task<Entity.TicketEntity.Ticket> FirstOrDefaultAsync(
            Expression<Func<Entity.TicketEntity.Ticket, bool>> predicate = null)
        {
            Entity.TicketEntity.Ticket ticket = null;
            try
            {
                ticket = predicate != null
                    ? await _context.Set<Entity.TicketEntity.Ticket>().Where(predicate)
                        .Include(x => x.Session)
                        .Include(x => x.Seat)
                        .Include(x => x.AdditionalServices)
                        .FirstOrDefaultAsync()
                    : await _context.Set<Entity.TicketEntity.Ticket>()
                        .Include(x => x.Session)
                        .Include(x => x.Seat)
                        .Include(x => x.AdditionalServices)
                        .OrderBy(x => x.Id).FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return ticket;
        }

        public async Task<bool> UpdateAsync(Entity.TicketEntity.Ticket entity)
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

        public async Task<bool> RemoveAsync(Entity.TicketEntity.Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Set<Entity.TicketEntity.Ticket>().Remove(entity);
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