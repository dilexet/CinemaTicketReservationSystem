using System;
using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels
{
    public class ModelDescriptionViewModel
    {
        public Guid Id { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Countries { get; set; }

        public IEnumerable<string> Genres { get; set; }
    }
}