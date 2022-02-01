using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels
{
    public class SessionRequestModel
    {
        public DateTime StartDate { get; set; }

        public Guid MovieId { get; set; }

        public Guid CinemaId { get; set; }

        public Guid HallId { get; set; }

        public IEnumerable<SessionAdditionalServiceModel> SessionAdditionalServices { get; set; }

        public IEnumerable<SessionSeatTypeModel> SessionSeatTypes { get; set; }
    }
}