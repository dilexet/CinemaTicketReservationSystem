using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Hall
{
    public class HallGetAllResponse : Response
    {
        public IEnumerable<HallViewModel> Halls { get; set; }
    }
}