using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Session
{
    public class SessionServiceGetAllResult : Result
    {
        public IEnumerable<SessionModel> Sessions { get; set; }
    }
}