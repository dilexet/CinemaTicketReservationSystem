namespace CinemaTicketReservationSystem.WebApi.Models.Response
{
    public class AuthorizeResponse : Response
    {
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}