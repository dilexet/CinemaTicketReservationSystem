using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema
{
    public class RowRequest
    {
        public uint NumberRow { get; set; }

        public uint NumberOfSeats { get; set; }

        public IEnumerable<SeatRequest> Seats { get; set; }
    }
}