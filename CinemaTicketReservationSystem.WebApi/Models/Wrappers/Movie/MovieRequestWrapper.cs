using System;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Movie
{
    public class MovieRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}