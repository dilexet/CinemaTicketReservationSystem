using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema
{
    public class CinemaViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public uint NumberOfHalls { get; set; }

        public string CityName { get; set; }

        public string Street { get; set; }

        public IEnumerable<AdditionalServiceViewModel> AdditionalServices { get; set; }

        public IEnumerable<HallViewModel> Halls { get; set; }
    }
}