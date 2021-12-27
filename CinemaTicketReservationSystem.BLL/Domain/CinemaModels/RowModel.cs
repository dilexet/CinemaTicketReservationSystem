using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Domain.CinemaModels
{
    public class RowModel
    {
        public Guid Id { get; set; }

        public uint NumberRow { get; set; }

        public uint NumberOfSeats { get; set; }

        public IEnumerable<SeatModel> Seats { get; set; }
    }
}