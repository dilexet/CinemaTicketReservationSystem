using System;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels
{
    public class CinemaModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AddressModel AddressModel { get; set; }
    }
}