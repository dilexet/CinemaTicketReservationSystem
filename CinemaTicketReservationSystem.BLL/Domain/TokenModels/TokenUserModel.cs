using System;

namespace CinemaTicketReservationSystem.BLL.Domain.TokenModels
{
    public class TokenUserModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Role { get; set; }
    }
}