using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.Movie;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Movie
{
    public class MovieGetAllResponse : Response
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }
    }
}