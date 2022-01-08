using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.BLL.Models.Results.Movie;
using CinemaTicketReservationSystem.BLL.Models.Results.Session;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IMovieFilterService
    {
        Task<MovieServiceGetMoviesResult> GetMoviesByFilter(MovieFilterParametersModel movieFilterParametersModel);

        Task<SessionServiceGetAllResult> GetSessionsForMovie(Guid movieId);

        Task<IEnumerable<string>> GetListOfMovieTitles(string movieTitleSearchQuery);

        Task<IEnumerable<string>> GetListOfCinemaNames(string cinemaTitleSearchQuery);

        Task<IEnumerable<string>> GetListOfCityNames(string cityTitleSearchQuery);
    }
}