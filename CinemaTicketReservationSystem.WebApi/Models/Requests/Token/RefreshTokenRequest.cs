namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Token
{
    public class RefreshTokenRequest
    {
        public string Username { get; set; }

        public string Token { get; set; }
    }
}