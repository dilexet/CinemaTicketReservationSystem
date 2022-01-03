using System;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels
{
    public class SessionSeatTypeModel
    {
        public Guid Id { get; set; }

        public double Price { get; set; }

        public string SeatType { get; set; }
    }
}