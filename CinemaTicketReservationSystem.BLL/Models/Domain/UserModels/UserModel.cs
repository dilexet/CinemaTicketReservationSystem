using System;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.UserModels
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public RoleModel RoleModel { get; set; }

        public string Password { get; set; }
    }
}