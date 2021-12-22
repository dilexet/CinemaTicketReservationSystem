using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Response
{
    public class Response
    {
        public int Code { get; set; }

        public bool Success { get; set; }

        public IEnumerable<object> Errors { get; set; }
    }
}