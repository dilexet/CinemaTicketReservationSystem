using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.MovieFilter
{
    public class SessionsForMovieModel
    {
        public CinemaModel Cinema { get; set; }

        public IEnumerable<SessionModel> Sessions { get; set; }
    }
}