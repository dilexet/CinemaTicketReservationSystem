using CinemaTicketReservationSystem.BLL.Models.Domain.HallModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Hall
{
    public class HallServiceResult : Result
    {
        public HallModel HallModel { get; set; }
    }
}