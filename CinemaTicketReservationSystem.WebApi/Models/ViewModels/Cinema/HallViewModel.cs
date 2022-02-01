using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema
{
    public class HallViewModel
    {
        public Guid Id { get; set; }

        public Guid CinemaId { get; set; }

        public string Name { get; set; }

        public string CinemaName { get; set; }

        public uint NumberOfRows { get; set; }

        public IEnumerable<string> SeatTypes { get; set; }

        public IEnumerable<RowViewModel> Rows { get; set; }
    }
}