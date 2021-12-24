using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Movie;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Movie
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MovieRepository> _log;

        public MovieRepository(ApplicationDbContext context, ILogger<MovieRepository> log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> CreateAsync(Entity.MovieEntity.Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = await _context.Set<Entity.MovieEntity.Movie>().AddAsync(entity);
            if (result != null)
            {
                return await SaveAsync();
            }

            return false;
        }

        public async Task<Entity.MovieEntity.Movie> FindByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Entity.MovieEntity.Movie movie = null;
            try
            {
                movie = await _context.Set<Entity.MovieEntity.Movie>()
                    .Where(x => x.Id.Equals(id))
                    .Include(x => x.Session)
                    .Include(x => x.MovieDescription)
                    .FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return movie;
        }

        public IQueryable<Entity.MovieEntity.Movie> GetBy(
            Expression<Func<Entity.MovieEntity.Movie, bool>> predicate = null)
        {
            IQueryable<Entity.MovieEntity.Movie> movies = null;
            try
            {
                movies = predicate != null
                    ? _context.Set<Entity.MovieEntity.Movie>()
                        .Where(predicate)
                        .Include(x => x.Session)
                        .Include(x => x.MovieDescription)
                    : _context.Set<Entity.MovieEntity.Movie>()
                        .Include(x => x.Session)
                        .Include(x => x.MovieDescription);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return movies;
        }

        public async Task<Entity.MovieEntity.Movie> FirstOrDefaultAsync(
            Expression<Func<Entity.MovieEntity.Movie, bool>> predicate = null)
        {
            Entity.MovieEntity.Movie movie = null;
            try
            {
                movie = predicate != null
                    ? await _context.Set<Entity.MovieEntity.Movie>().Where(predicate)
                        .Include(x => x.Session)
                        .Include(x => x.MovieDescription)
                        .FirstOrDefaultAsync()
                    : await _context.Set<Entity.MovieEntity.Movie>()
                        .Include(x => x.Session)
                        .Include(x => x.MovieDescription)
                        .OrderBy(x => x.Id).FirstOrDefaultAsync();
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return movie;
        }

        public async Task<bool> UpdateAsync(Entity.MovieEntity.Movie entity)
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

        public async Task<bool> RemoveAsync(Entity.MovieEntity.Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Set<Entity.MovieEntity.Movie>().Remove(entity);
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