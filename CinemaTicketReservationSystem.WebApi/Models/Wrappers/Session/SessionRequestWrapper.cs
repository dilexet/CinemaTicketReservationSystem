using System;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Session
{
    public class SessionRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}