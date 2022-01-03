using System;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session
{
    public class SessionSeatTypeViewModel
    {
        public Guid Id { get; set; }

        public double Price { get; set; }

        public string SeatType { get; set; }
    }
}