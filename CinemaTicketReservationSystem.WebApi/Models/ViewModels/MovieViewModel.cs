using System;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ModelDescriptionViewModel ModelDescriptionViewModel { get; set; }
    }
}