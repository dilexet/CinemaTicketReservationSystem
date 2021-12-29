using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Domain.HallModels;

namespace CinemaTicketReservationSystem.BLL.Results.Hall
{
    public class HallServiceGetAllResult : Result
    {
        public IEnumerable<HallModel> HallModels { get; set; }
    }
}