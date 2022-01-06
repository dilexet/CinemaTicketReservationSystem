using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.User;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Booking
{
    public class BookedOrderViewModel
    {
        public Guid Id { get; set; }

        public double TotalPrice { get; set; }

        public string CinemaName { get; set; }

        public string HallName { get; set; }

        public string MovieName { get; set; }

        public UserProfileViewModel UserProfile { get; set; }

        public IEnumerable<SessionSeatViewModel> ReservedSessionSeats { get; set; }

        public IEnumerable<SessionAdditionalServiceViewModel> SelectedSessionAdditionalServices { get; set; }
    }
}