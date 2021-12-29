using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.AdditionalService
{
    public class AdditionalServiceResponse : Response
    {
        public AdditionalServiceViewModel AdditionalService { get; set; }
    }
}