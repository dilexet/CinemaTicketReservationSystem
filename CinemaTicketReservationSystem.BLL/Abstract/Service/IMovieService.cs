using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Filters;
using CinemaTicketReservationSystem.BLL.Results.Movie;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IMovieService
    {
        Task<MovieServiceResult> AddMovie(MovieModel movieModel);

        Task<MovieServiceResult> UpdateMovieInfo(Guid id, MovieModel movieModel);

        Task<MovieServiceRemoveResult> RemoveMovie(Guid id);

        Task<MovieServiceGetMoviesResult> GetMovies(FilterParametersModel filter);

        Task<MovieServiceResult> GetMovieById(Guid id);
    }
}