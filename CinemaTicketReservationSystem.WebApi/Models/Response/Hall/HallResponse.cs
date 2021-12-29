using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Hall
{
    public class HallResponse : Response
    {
        public HallViewModel Hall { get; set; }
    }
}