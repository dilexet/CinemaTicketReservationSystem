using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Cinema
{
    public class CinemaServiceGetAllResult : Result
    {
        public IEnumerable<CinemaModel> CinemaModels { get; set; }
    }
}