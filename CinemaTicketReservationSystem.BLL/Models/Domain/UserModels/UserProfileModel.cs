using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.UserModels
{
    public class UserProfileModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IEnumerable<BookedOrderModel> TicketsModel { get; set; }
    }
}