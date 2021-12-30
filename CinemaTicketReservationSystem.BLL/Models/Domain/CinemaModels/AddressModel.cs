using System;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels
{
    public class AddressModel
    {
        public Guid Id { get; set; }

        public string CityName { get; set; }

        public string Street { get; set; }
    }
}