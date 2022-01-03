using System;
using CinemaTicketReservationSystem.BLL.Models.Domain.AdditionalServiceModels;

namespace CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels
{
    public class SessionAdditionalServiceModel
    {
        public Guid Id { get; set; }

        public double Price { get; set; }

        public virtual AdditionalServiceModel AdditionalService { get; set; }
    }
}