using System;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema
{
    public class CinemaRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}