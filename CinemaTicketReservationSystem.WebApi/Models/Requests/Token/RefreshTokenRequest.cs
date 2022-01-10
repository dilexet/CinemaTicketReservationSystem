using System;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Token
{
    public class RefreshTokenRequest
    {
        public Guid UserId { get; set; }

        public string Token { get; set; }
    }
}