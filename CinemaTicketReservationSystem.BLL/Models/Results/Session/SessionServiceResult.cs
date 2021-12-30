using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Session
{
    public class SessionServiceResult : Result
    {
        public SessionModel Session { get; set; }
    }
}