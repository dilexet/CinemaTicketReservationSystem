using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Session
{
    public class SessionGetAllResponse : Response
    {
        public IEnumerable<SessionViewModel> Sessions { get; set; }
    }
}