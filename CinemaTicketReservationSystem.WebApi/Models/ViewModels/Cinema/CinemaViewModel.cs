using System;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema
{
    public class CinemaViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string CityName { get; set; }

        public string Street { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}