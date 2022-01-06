using System;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Hall
{
    public class HallRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}