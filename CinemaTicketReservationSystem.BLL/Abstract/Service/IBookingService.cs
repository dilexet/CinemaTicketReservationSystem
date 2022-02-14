using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Booking;
using CinemaTicketReservationSystem.BLL.Models.Results.Session;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IBookingService
    {
        Task<BookingServiceResult> BookTickets(Guid id, BookingModel bookingModel);

        Task<SessionServiceResult> GetSessionById(Guid id);
    }
}