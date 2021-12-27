using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.DAL.Abstract.Movie;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
namespace CinemaTicketReservationSystem.DAL.Repository.Movie
{
    public class MovieRepository : BaseRepository<Entity.MovieEntity.Movie>, IMovieRepository
    {
        private readonly ILogger<MovieRepository> _log;

        public MovieRepository(ApplicationDbContext context, ILogger<MovieRepository> log)
            : base(context)
        {
            _log = log;
        }

        public override async Task<bool> CreateAsync(Entity.MovieEntity.Movie movie)
        {
            try
            {
                return await base.CreateAsync(movie);
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

        public override async Task<Entity.MovieEntity.Movie> FindByIdAsync(Guid? id)
        {
            Entity.MovieEntity.Movie movie = null;
            try
            {
                movie = await base.FindByIdAsync(id);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }
            catch (ArgumentNullException e)
            {
                _log.LogError(e.ToString());
            }

            return movie;
        }

        public override IQueryable<Entity.MovieEntity.Movie> GetBy(
            Expression<Func<Entity.MovieEntity.Movie, bool>> predicate = null)
        {
            IQueryable<Entity.MovieEntity.Movie> movies = null;
            try
            {
                movies = base.GetBy(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return movies;
        }

        public override async Task<Entity.MovieEntity.Movie> FirstOrDefaultAsync(
            Expression<Func<Entity.MovieEntity.Movie, bool>> predicate = null)
        {
            Entity.MovieEntity.Movie movie = null;
            try
            {
                movie = await base.FirstOrDefaultAsync(predicate);
            }
            catch (SqlException e)
            {
                _log.LogError(e.ToString());
            }

            return movie;
        }

        public override async Task<bool> UpdateAsync(Entity.MovieEntity.Movie movie)
        {
            try
            {
                return await base.UpdateAsync(movie);
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

        public override async Task<bool> RemoveAsync(Entity.MovieEntity.Movie movie)
        {
            try
            {
                return await base.RemoveAsync(movie);
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