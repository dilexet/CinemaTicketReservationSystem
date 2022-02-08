using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.MovieFilter
{
    public class SessionsForMovieViewModel
    {
        public CinemaViewModel Cinema { get; set; }

        public IEnumerable<SessionViewModel> Sessions { get; set; }
    }
}