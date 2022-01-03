using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Session
{
    public class SessionResponse : Response
    {
        public SessionViewModel Session { get; set; }
    }
}