using System;

namespace CinemaTicketReservationSystem.BLL.Domain.AuthModels
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public RoleModel Role { get; set; }
    }
}