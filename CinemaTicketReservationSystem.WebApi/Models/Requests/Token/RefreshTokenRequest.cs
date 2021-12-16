using System;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Token
{
    public class RefreshTokenRequest
    {
        public String Username { get; set; }
        public String Token { get; set; }
    }
}