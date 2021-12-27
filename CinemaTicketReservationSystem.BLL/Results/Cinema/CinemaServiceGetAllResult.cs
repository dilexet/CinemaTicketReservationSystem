using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Domain.CinemaModels;

namespace CinemaTicketReservationSystem.BLL.Results.Cinema
{
    public class CinemaServiceGetAllResult : Result
    {
        public IEnumerable<CinemaModel> CinemaModels { get; set; }
    }
}