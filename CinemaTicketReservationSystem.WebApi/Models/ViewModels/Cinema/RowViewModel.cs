using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema
{
    public class RowViewModel
    {
        public Guid Id { get; set; }

        public uint NumberRow { get; set; }

        public uint NumberOfSeats { get; set; }

        public IEnumerable<SeatViewModel> Seats { get; set; }
    }
}