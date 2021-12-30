using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Session
{
    public class SessionRequest
    {
        public DateTime StartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public string HallName { get; set; }

        public IEnumerable<SessionAdditionalServiceRequest> SessionAdditionalServicesRequest { get; set; }

        public IEnumerable<SessionSeatTypeRequest> SessionSeatTypesRequest { get; set; }
    }
}