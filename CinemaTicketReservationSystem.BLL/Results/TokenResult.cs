using System;
using CinemaTicketReservationSystem.DAL.Entity;

namespace CinemaTicketReservationSystem.BLL.Results
{
    public class TokenResult
    {
        public bool Success { get; set; }
        public String JwtToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public String Error { get; set; }
    }
}