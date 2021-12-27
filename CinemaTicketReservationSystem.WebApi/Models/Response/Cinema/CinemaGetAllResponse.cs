using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Cinema
{
    public class CinemaGetAllResponse : Response
    {
        public IEnumerable<CinemaViewModel> Cinemas { get; set; }
    }
}