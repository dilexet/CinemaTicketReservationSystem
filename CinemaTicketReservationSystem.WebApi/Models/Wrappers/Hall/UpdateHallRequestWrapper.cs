using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Hall
{
    public class UpdateHallRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public HallRequest HallRequest { get; set; }
    }
}