using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels
{
    public class BookingModel
    {
        public Guid UserProfileId { get; set; }

        public IEnumerable<Guid> SessionSeatsId { get; set; }

        public IEnumerable<Guid> SessionAdditionalServicesId { get; set; }
    }
}