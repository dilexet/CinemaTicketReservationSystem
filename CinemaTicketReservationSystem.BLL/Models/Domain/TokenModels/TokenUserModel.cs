using System;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels
{
    public class TokenUserModel
    {
        public Guid Id { get; set; }

        public Guid UserProfileId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}