using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.Abstract;

namespace CinemaTicketReservationSystem.WebApi.Models.Response
{
    public class Response : IResponse
    {
        public int Code { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}