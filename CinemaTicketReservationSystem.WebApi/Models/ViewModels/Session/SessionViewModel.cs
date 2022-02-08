using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Movie;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session
{
    public class SessionViewModel
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public double HallWorkload { get; set; }

        public MovieViewModel Movie { get; set; }

        public HallViewModel Hall { get; set; }

        public IEnumerable<SessionAdditionalServiceViewModel> SessionAdditionalServices { get; set; }

        public IEnumerable<SessionSeatViewModel> SessionSeats { get; set; }

        public IEnumerable<SessionSeatTypeViewModel> SessionSeatTypes { get; set; }
    }
}