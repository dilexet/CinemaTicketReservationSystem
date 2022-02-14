using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels
{
    public class BookedOrderModel
    {
        public Guid Id { get; set; }

        public double TotalPrice { get; set; }

        public SessionModel Session { get; set; }

        public UserProfileModel UserProfileModel { get; set; }

        public IEnumerable<SessionSeatModel> ReservedSessionSeats { get; set; }

        public IEnumerable<BookedServiceModel> SelectedSessionAdditionalServices { get; set; }
    }
}