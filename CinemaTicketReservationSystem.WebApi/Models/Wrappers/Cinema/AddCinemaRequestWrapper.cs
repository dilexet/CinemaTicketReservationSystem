using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema
{
    public class AddCinemaRequestWrapper
    {
        [FromBody]
        public CinemaRequest CinemaRequest { get; set; }
    }
}