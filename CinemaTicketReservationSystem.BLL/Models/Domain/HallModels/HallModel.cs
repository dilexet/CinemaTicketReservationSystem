using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.HallModels
{
    public class HallModel
    {
        public Guid Id { get; set; }

        public Guid CinemaId { get; set; }

        public string Name { get; set; }

        public string CinemaName { get; set; }

        public uint NumberOfRows { get; set; }

        public IEnumerable<string> SeatTypes { get; set; }

        public IEnumerable<RowModel> Rows { get; set; }
    }
}