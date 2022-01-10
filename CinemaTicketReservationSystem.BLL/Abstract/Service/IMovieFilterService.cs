using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.BLL.Models.Results.Movie;
using CinemaTicketReservationSystem.BLL.Models.Results.Search;
using CinemaTicketReservationSystem.BLL.Models.Results.Session;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IMovieFilterService
    {
        Task<MovieServiceGetMoviesResult> GetMoviesByFilter(MovieFilterParametersModel movieFilterParametersModel);

        Task<SessionServiceGetAllResult> GetSessionsForMovie(Guid movieId);

        Task<SearchSuggestionResult> GetListOfMovieTitles(string movieTitleSearchQuery);

        Task<SearchSuggestionResult> GetListOfCinemaNames(string cinemaTitleSearchQuery);

        Task<SearchSuggestionResult> GetListOfCityNames(string cityTitleSearchQuery);
    }
}