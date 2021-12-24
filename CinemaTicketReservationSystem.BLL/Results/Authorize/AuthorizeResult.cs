namespace CinemaTicketReservationSystem.BLL.Results.Authorize
{
    public class AuthorizeResult : Result
    {
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}