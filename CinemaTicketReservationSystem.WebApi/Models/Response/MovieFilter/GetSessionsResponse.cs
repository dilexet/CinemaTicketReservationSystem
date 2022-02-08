using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Movie;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.MovieFilter;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.MovieFilter
{
    public class GetSessionsResponse : Response
    {
        public IEnumerable<SessionsForMovieViewModel> Sessions { get; set; }

        public MovieViewModel Movie { get; set; }
    }
}