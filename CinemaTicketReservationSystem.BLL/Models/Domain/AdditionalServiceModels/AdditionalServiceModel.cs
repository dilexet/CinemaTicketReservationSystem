using System;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.AdditionalServiceModels
{
    public class AdditionalServiceModel
    {
        public Guid Id { get; set; }

        public Guid CinemaId { get; set; }

        public string CinemaName { get; set; }

        public string Name { get; set; }
    }
}