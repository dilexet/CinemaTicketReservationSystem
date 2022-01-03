using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Cinema
{
    public class CinemaResponse : Response
    {
        public CinemaViewModel Cinema { get; set; }
    }
}