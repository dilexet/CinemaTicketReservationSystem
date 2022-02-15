using CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.Booking
{
    public class BookingServiceResult : Result
    {
        public BookedOrderModel BookedOrder { get; set; }
    }
}