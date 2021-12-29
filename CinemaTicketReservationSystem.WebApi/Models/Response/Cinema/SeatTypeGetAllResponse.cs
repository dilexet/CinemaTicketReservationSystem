using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Cinema
{
    public class SeatTypeGetAllResponse : Response
    {
        public IEnumerable<string> SeatTypes { get; set; }
    }
}