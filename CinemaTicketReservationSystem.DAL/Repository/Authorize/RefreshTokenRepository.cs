using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Authorize;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Authorize
{
    public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly ILogger<RefreshTokenRepository> _log;

        public RefreshTokenRepository(ApplicationDbContext context, ILogger<RefreshTokenRepository> log)
            : base(context)
        {
            _log = log;
        }

        public override async Task<bool> CreateAsync(RefreshToken refreshToken)
        {
            try
            {
                return await base.CreateAsync(refreshToken);
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

        public override async Task<RefreshToken> FindByIdAsync(Guid? id)
        {
            RefreshToken refreshToken = null;
            try
            {
                refreshToken = await base.FindByIdAsync(id);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return refreshToken;
        }

        public override IQueryable<RefreshToken> GetBy(Expression<Func<RefreshToken, bool>> predicate = null)
        {
            IQueryable<RefreshToken> refreshTokens = null;
            try
            {
                refreshTokens = base.GetBy(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return refreshTokens;
        }

        public override async Task<RefreshToken> FirstOrDefaultAsync(
            Expression<Func<RefreshToken, bool>> predicate = null)
        {
            RefreshToken refreshToken = null;
            try
            {
                refreshToken = await base.FirstOrDefaultAsync(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return refreshToken;
        }

        public override async Task<bool> UpdateAsync(RefreshToken refreshToken)
        {
            try
            {
                return await base.UpdateAsync(refreshToken);
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

        public override async Task<bool> RemoveAsync(RefreshToken refreshToken)
        {
            try
            {
                return await base.RemoveAsync(refreshToken);
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