﻿using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels
{
    public class BookedOrderModel
    {
        public double TotalPrice { get; set; }

        public string CinemaName { get; set; }

        public string HallName { get; set; }

        public string MovieName { get; set; }

        public UserProfileModel UserProfileModel { get; set; }

        public IEnumerable<SessionSeatModel> ReservedSessionSeats { get; set; }

        public IEnumerable<SessionAdditionalServiceModel> SelectedSessionAdditionalServices { get; set; }
    }
}