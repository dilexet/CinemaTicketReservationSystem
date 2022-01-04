using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.User
{
    public class UserProfileViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IEnumerable<SessionSeatViewModel> Tickets { get; set; }
    }
}