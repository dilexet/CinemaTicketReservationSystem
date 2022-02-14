using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Booking;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.User
{
    public class UserProfileViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IEnumerable<BookedOrderViewModel> Tickets { get; set; }
    }
}