using System;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.HallModels
{
    public class SeatModel
    {
        public Guid Id { get; set; }

        public uint NumberSeat { get; set; }

        public uint NumberRow { get; set; }

        public string SeatType { get; set; }
    }
}