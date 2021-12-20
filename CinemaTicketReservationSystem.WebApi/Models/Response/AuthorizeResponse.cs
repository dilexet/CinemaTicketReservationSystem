using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Response
{
    public class AuthorizeResponse
    {
        public int Code { get; set; }

        public bool Success { get; set; }

        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }

        public IEnumerable<object> Errors { get; set; }
    }
}