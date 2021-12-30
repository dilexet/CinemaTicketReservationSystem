using System;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session
{
    public class SessionSeatViewModel
    {
        public Guid Id { get; set; }

        public string TicketState { get; set; }

        public SeatViewModel Seat { get; set; }

        public SessionSeatTypeViewModel SessionSeatType { get; set; }
    }
}