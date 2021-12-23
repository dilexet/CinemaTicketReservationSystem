namespace CinemaTicketReservationSystem.WebApi.Models.Response.Authorize
{
    public class AuthorizeResponse : Response
    {
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}