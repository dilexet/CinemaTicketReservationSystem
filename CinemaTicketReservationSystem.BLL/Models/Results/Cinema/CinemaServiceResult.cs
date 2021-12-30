using CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Cinema
{
    public class CinemaServiceResult : Result
    {
        public CinemaModel CinemaModel { get; set; }
    }
}