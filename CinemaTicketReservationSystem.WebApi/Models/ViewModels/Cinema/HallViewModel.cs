using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema
{
    public class HallViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public uint NumberOfSeats { get; set; }

        public IEnumerable<RowViewModel> Rows { get; set; }
    }
}