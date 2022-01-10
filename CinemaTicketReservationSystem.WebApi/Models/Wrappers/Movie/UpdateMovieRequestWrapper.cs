using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Movie;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Movie
{
    public class UpdateMovieRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public MovieRequest MovieRequest { get; set; }
    }
}