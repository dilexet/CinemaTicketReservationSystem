using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Booking
{
    public class BookTicketsRequest
    {
        public Guid UserProfileId { get; set; }

        public IEnumerable<Guid> SessionSeatsId { get; set; }

        public IEnumerable<Guid> SessionAdditionalServicesId { get; set; }
    }
}