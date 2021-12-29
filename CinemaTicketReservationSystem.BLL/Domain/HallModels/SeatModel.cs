using System;

namespace CinemaTicketReservationSystem.BLL.Domain.HallModels
{
    public class SeatModel
    {
        public Guid Id { get; set; }

        public uint NumberSeat { get; set; }

        public string SeatType { get; set; }
    }
}