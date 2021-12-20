using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Results
{
    public class AuthorizeResult
    {
        public bool Success { get; set; }

        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }

        public IEnumerable<object> Errors { get; set; }
    }
}