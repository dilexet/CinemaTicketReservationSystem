using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Booking;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Booking
{
    public class BookTicketsResponse : Response
    {
        public BookedOrderViewModel BookedOrderViewModel { get; set; }
    }
}