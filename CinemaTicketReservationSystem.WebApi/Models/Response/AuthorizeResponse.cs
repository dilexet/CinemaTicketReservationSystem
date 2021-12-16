using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Response
{
    public class AuthorizeResponse
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public String JwtToken { get; set; }
        public String RefreshToken { get; set; }
        public IEnumerable<String> Errors { get; set; }
    }
}