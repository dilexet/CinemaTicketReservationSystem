using System;
using CinemaTicketReservationSystem.BLL.Models.Domain.HallModels;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels
{
    public class SessionSeatModel
    {
        public Guid Id { get; set; }

        public string TicketState { get; set; }

        public SeatModel Seat { get; set; }

        public SessionSeatTypeModel SessionSeatType { get; set; }
    }
}