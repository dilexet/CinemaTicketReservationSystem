using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Cinema
{
    public class SeatTypeGetAllResponse : Response
    {
        public IEnumerable<SeatTypeViewModel> SeatTypes { get; set; }
    }
}