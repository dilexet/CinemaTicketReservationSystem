using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.HallModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Hall
{
    public class HallServiceGetAllResult : Result
    {
        public IEnumerable<HallModel> HallModels { get; set; }
    }
}