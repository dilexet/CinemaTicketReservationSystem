using CinemaTicketReservationSystem.BLL.Domain.CinemaModels;

namespace CinemaTicketReservationSystem.BLL.Results.Cinema
{
    public class CinemaServiceResult : Result
    {
        public CinemaModel CinemaModel { get; set; }
    }
}