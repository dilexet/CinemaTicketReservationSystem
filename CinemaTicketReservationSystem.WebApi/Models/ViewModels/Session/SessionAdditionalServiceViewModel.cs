using System;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Cinema;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Session
{
    public class SessionAdditionalServiceViewModel
    {
        public Guid Id { get; set; }

        public double Price { get; set; }

        public virtual AdditionalServiceViewModel AdditionalService { get; set; }
    }
}