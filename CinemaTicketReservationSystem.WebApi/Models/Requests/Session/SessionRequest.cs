using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Session
{
    public class SessionRequest
    {
        public DateTime StartDate { get; set; }

        public Guid MovieId { get; set; }

        public Guid CinemaId { get; set; }

        public Guid HallId { get; set; }

        public IEnumerable<SessionAdditionalServiceRequest> SessionAdditionalServices { get; set; }

        public IEnumerable<SessionSeatTypeRequest> SessionSeatTypes { get; set; }
    }
}