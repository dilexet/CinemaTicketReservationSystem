using CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Booking
{
    public class BookingServiceResult : Result
    {
        public BookedOrderModel BookedOrder { get; set; }
    }
}