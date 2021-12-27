using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.BLL.Domain.CinemaModels
{
    public class CinemaModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public uint NumberOfHalls { get; set; }

        public AddressModel AddressModel { get; set; }

        public IEnumerable<AdditionalServiceModel> AdditionalServices { get; set; }

        public IEnumerable<HallModel> Halls { get; set; }
    }
}