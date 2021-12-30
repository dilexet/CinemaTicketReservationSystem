﻿using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels
{
    public class SessionRequestModel
    {
        public DateTime StartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public string HallName { get; set; }

        public IEnumerable<SessionAdditionalServiceModel> SessionAdditionalServices { get; set; }

        public IEnumerable<SessionSeatTypeModel> SessionSeatTypes { get; set; }
    }
}