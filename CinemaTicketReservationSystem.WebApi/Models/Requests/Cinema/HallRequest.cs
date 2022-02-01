using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema
{
    public class HallRequest
    {
        public string Name { get; set; }

        public uint NumberOfRows { get; set; }

        public IEnumerable<RowRequest> Rows { get; set; }
    }
}