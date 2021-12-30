using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Models.Results
{
    public class Result
    {
        public bool Success { get; set; }

        public IEnumerable<object> Errors { get; set; }
    }
}