using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Models.Results.SeatType
{
    public class SeatTypeServiceGetAllResult : Result
    {
        public IEnumerable<string> SeatTypesList { get; set; }
    }
}