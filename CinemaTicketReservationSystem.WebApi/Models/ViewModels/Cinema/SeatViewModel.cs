using System;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema
{
    public class SeatViewModel
    {
        public Guid Id { get; set; }

        public uint NumberSeat { get; set; }

        public string SeatType { get; set; }
    }
}