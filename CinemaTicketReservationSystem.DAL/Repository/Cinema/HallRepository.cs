using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Cinema;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Cinema
{
    public class HallRepository : BaseRepository<Hall>, IHallRepository
    {
        private readonly ILogger<HallRepository> _log;

        public HallRepository(ApplicationDbContext context, ILogger<HallRepository> log)
            : base(context)
        {
            _log = log;
        }

        public override async Task<bool> CreateAsync(Hall hall)
        {
            try
            {
                return await base.CreateAsync(hall);
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

        public override async Task<Hall> FindByIdAsync(Guid? id)
        {
            Hall hall = null;
            try
            {
                hall = await base.FindByIdAsync(id);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return hall;
        }

        public override IQueryable<Hall> GetBy(
            Expression<Func<Hall, bool>> predicate = null)
        {
            IQueryable<Hall> halls = null;
            try
            {
                halls = base.GetBy(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return halls;
        }

        public override async Task<Hall> FirstOrDefaultAsync(
            Expression<Func<Hall, bool>> predicate = null)
        {
            Hall hall = null;
            try
            {
                hall = await base.FirstOrDefaultAsync(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return hall;
        }

        public override async Task<bool> UpdateAsync(Hall hall)
        {
            try
            {
                return await base.UpdateAsync(hall);
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

        public override async Task<bool> RemoveAsync(Hall hall)
        {
            try
            {
                return await base.RemoveAsync(hall);
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