using CinemaTicketReservationSystem.DAL.Entity;

namespace CinemaTicketReservationSystem.BLL.Results
{
    public class TokenResult
    {
        public bool Success { get; set; }

        public string JwtToken { get; set; }

        public RefreshToken RefreshToken { get; set; }

        public string Error { get; set; }
    }
}