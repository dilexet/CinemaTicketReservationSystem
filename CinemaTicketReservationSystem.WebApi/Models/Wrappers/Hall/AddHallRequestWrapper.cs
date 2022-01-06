using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Hall
{
    public class AddHallRequestWrapper
    {
        [FromRoute(Name = "cinemaId")]
        public Guid CinemaId { get; set; }

        [FromBody]
        public HallRequest HallRequest { get; set; }
    }
}