using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;

namespace CinemaTicketReservationSystem.BLL.Results
{
    public class TokenResult : Result
    {
        public string JwtToken { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}