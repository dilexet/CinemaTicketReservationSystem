using System;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels
{
    public class AddressModel
    {
        public Guid Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}