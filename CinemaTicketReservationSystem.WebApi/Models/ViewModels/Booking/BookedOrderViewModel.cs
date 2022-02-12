using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Booking
{
    public class BookedOrderViewModel
    {
        public Guid Id { get; set; }

        public double TotalPrice { get; set; }

        public SessionViewModel Session { get; set; }

        public IEnumerable<SessionSeatViewModel> ReservedSessionSeats { get; set; }

        public IEnumerable<SessionAdditionalServiceViewModel> SelectedSessionAdditionalServices { get; set; }
    }
}