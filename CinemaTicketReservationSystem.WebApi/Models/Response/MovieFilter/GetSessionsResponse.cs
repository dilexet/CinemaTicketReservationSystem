using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Movie;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.MovieFilter
{
    public class GetSessionsResponse : Response
    {
        public IEnumerable<SessionViewModel> Sessions { get; set; }

        public MovieViewModel Movie { get; set; }
    }
}