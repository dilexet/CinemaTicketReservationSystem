using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Booking
{
    public class BookedServiceViewModel
    {
        public uint NumberOfServices { get; set; }

        public SessionAdditionalServiceModel SelectedSessionAdditionalService { get; set; }
    }
}