using System;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.AdditionalService
{
    public class AdditionalServiceRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}