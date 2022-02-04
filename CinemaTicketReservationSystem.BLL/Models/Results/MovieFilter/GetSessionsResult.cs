using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.MovieModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.MovieFilter
{
    public class GetSessionsResult : Result
    {
        public IEnumerable<SessionModel> Sessions { get; set; }

        public MovieModel Movie { get; set; }
    }
}