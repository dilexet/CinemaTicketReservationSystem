using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.HallModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels
{
    public class SessionModel
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public MovieModel Movie { get; set; }

        public HallModel Hall { get; set; }

        public IEnumerable<SessionAdditionalServiceModel> SessionAdditionalServices { get; set; }

        public IEnumerable<SessionSeatModel> SessionSeats { get; set; }
    }
}