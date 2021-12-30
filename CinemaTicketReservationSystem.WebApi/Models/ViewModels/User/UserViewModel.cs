using System;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string RoleName { get; set; }
    }
}