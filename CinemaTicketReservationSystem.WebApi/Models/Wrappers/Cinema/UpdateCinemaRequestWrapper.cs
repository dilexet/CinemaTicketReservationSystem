using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema
{
    public class UpdateCinemaRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public CinemaRequest CinemaRequest { get; set; }
    }
}