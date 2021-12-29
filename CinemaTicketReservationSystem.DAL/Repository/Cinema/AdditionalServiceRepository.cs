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
    public class AdditionalServiceRepository : BaseRepository<AdditionalService>, IAdditionalRepository
    {
        private readonly ILogger<AdditionalServiceRepository> _log;

        public AdditionalServiceRepository(ApplicationDbContext context, ILogger<AdditionalServiceRepository> log)
            : base(context)
        {
            _log = log;
        }

        public override async Task<bool> CreateAsync(AdditionalService additionalService)
        {
            try
            {
                return await base.CreateAsync(additionalService);
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

        public override async Task<AdditionalService> FindByIdAsync(Guid? id)
        {
            AdditionalService additionalService = null;
            try
            {
                additionalService = await base.FindByIdAsync(id);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return additionalService;
        }

        public override IQueryable<AdditionalService> GetBy(
            Expression<Func<AdditionalService, bool>> predicate = null)
        {
            IQueryable<AdditionalService> additionalServices = null;
            try
            {
                additionalServices = base.GetBy(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return additionalServices;
        }

        public override async Task<AdditionalService> FirstOrDefaultAsync(
            Expression<Func<AdditionalService, bool>> predicate = null)
        {
            AdditionalService additionalService = null;
            try
            {
                additionalService = await base.FirstOrDefaultAsync(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return additionalService;
        }

        public override async Task<bool> UpdateAsync(AdditionalService additionalService)
        {
            try
            {
                return await base.UpdateAsync(additionalService);
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

        public override async Task<bool> RemoveAsync(AdditionalService additionalService)
        {
            try
            {
                return await base.RemoveAsync(additionalService);
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