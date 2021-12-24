using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Authorize;
using CinemaTicketReservationSystem.DAL.Context;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Authorize
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RefreshTokenRepository> _log;

        public RefreshTokenRepository(ApplicationDbContext context, ILogger<RefreshTokenRepository> log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> CreateAsync(RefreshToken refreshToken)
        {
            if (refreshToken == null)
            {
                throw new ArgumentNullException(nameof(refreshToken));
            }

            var result = await _context.Set<RefreshToken>().AddAsync(refreshToken);
            if (result != null)
            {
                return await SaveAsync();
            }

            return false;
        }

        public async Task<RefreshToken> FindByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            RefreshToken refreshToken = null;
            try
            {
                refreshToken = await _context.Set<RefreshToken>()
                    .Where(x => x.Id.Equals(id))
                    .Include(x => x.User)
                    .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return refreshToken;
        }

        public IQueryable<RefreshToken> GetBy(Expression<Func<RefreshToken, bool>> predicate = null)
        {
            IQueryable<RefreshToken> refreshTokens = null;
            try
            {
                refreshTokens = predicate != null
                    ? _context.Set<RefreshToken>().Where(predicate).Include(x => x.User)
                    : _context.Set<RefreshToken>().Include(x => x.User);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return refreshTokens;
        }

        public async Task<RefreshToken> FirstOrDefaultAsync(Expression<Func<RefreshToken, bool>> predicate = null)
        {
            RefreshToken refreshToken = null;
            try
            {
                refreshToken = predicate != null
                    ? await _context.Set<RefreshToken>().Where(predicate)
                        .Include(x => x.User)
                        .FirstOrDefaultAsync()
                    : await _context.Set<RefreshToken>().Include(x => x.User)
                        .OrderBy(x => x.Id)
                        .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return refreshToken;
        }

        public async Task<bool> UpdateAsync(RefreshToken refreshToken)
        {
            if (refreshToken == null)
            {
                throw new ArgumentNullException(nameof(refreshToken));
            }

            try
            {
                _context.Entry(refreshToken).State = EntityState.Modified;
                return await SaveAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
                return false;
            }
        }

        public async Task<bool> RemoveAsync(RefreshToken refreshToken)
        {
            if (refreshToken == null)
            {
                throw new ArgumentNullException(nameof(refreshToken));
            }

            try
            {
                _context.Set<RefreshToken>().Remove(refreshToken);
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