using CinemaTicketReservationSystem.WebApi.Models.Requests.Movie;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Movie
{
    public class AddMovieRequestWrapper
    {
        [FromBody]
        public MovieRequest MovieRequest { get; set; }
    }
}