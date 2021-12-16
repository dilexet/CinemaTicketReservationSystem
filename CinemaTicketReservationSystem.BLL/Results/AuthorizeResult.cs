using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Results
{
    public class AuthorizeResult
    {
        public bool Success { get; set; }
        public String JwtToken { get; set; }
        public String RefreshToken { get; set; }
        public IEnumerable<String> Errors { get; set; }
    }
}