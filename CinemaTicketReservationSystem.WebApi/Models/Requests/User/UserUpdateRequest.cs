using System;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.User
{
    public class UserUpdateRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }
    }
}