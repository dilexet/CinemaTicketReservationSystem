namespace CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels
{
    public class JwtOptions
    {
        public string AccessTokenSecret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int AccessTokenExpirationMinutes { get; set; }
    }
}