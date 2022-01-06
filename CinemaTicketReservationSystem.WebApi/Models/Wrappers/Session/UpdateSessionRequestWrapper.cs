using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Session;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Session
{
    public class UpdateSessionRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public SessionRequest SessionRequest { get; set; }
    }
}