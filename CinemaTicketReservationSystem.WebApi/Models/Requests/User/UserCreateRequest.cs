using System;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.User
{
    public class UserCreateRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}