using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Cinema;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Cinema
{
    public class CinemaRepository : BaseRepository<Entity.CinemaEntity.Cinema>, ICinemaRepository
    {
        private readonly ILogger<CinemaRepository> _log;

        public CinemaRepository(ApplicationDbContext context, ILogger<CinemaRepository> log)
            : base(context)
        {
            _log = log;
        }

        public override async Task<bool> CreateAsync(Entity.CinemaEntity.Cinema cinema)
        {
            try
            {
                return await base.CreateAsync(cinema);
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

        public override async Task<Entity.CinemaEntity.Cinema> FindByIdAsync(Guid? id)
        {
            Entity.CinemaEntity.Cinema cinema = null;
            try
            {
                cinema = await base.FindByIdAsync(id);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return cinema;
        }

        public override IQueryable<Entity.CinemaEntity.Cinema> GetBy(Expression<Func<Entity.CinemaEntity.Cinema, bool>> predicate = null)
        {
            IQueryable<Entity.CinemaEntity.Cinema> cinemas = null;
            try
            {
                cinemas = base.GetBy(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return cinemas;
        }

        public override async Task<Entity.CinemaEntity.Cinema> FirstOrDefaultAsync(Expression<Func<Entity.CinemaEntity.Cinema, bool>> predicate = null)
        {
            Entity.CinemaEntity.Cinema cinema = null;
            try
            {
                cinema = await base.FirstOrDefaultAsync(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return cinema;
        }

        public override async Task<bool> UpdateAsync(Entity.CinemaEntity.Cinema cinema)
        {
            try
            {
                return await base.UpdateAsync(cinema);
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

        public override async Task<bool> RemoveAsync(Entity.CinemaEntity.Cinema cinema)
        {
            try
            {
                return await base.RemoveAsync(cinema);
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