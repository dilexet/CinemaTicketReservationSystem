using System;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema
{
    public class AdditionalServiceViewModel
    {
        public Guid Id { get; set; }

        public Guid CinemaId { get; set; }

        public string Name { get; set; }

        public string CinemaName { get; set; }
    }
}