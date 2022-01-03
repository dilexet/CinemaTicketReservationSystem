using System;
using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.AdditionalServiceModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.HallModels;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels
{
    public class CinemaModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AddressModel AddressModel { get; set; }

        public IEnumerable<AdditionalServiceModel> AdditionalServices { get; set; }

        public IEnumerable<HallModel> Halls { get; set; }
    }
}