using System;

namespace CinemaTicketReservationSystem.BLL.Domain.TokenModels
{
    public class TokenUserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}