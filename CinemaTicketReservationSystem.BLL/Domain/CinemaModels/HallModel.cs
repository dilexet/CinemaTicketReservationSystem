using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Domain.CinemaModels
{
    public class HallModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public uint NumberOfSeats { get; set; }

        public IEnumerable<RowModel> Rows { get; set; }
    }
}