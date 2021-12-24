namespace CinemaTicketReservationSystem.BLL.Results
{
    public class AuthorizeResult : Result
    {
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}