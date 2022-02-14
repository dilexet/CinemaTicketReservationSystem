using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels
{
    public class BookedServiceModel
    {
        public uint NumberOfServices { get; set; }

        public SessionAdditionalServiceModel SelectedSessionAdditionalService { get; set; }
    }
}