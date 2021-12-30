using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.BLL.Models.Results.Movie;

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