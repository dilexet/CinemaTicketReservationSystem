using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Booking;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.Booking
{
    public class BookTicketsRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public BookTicketsRequest BookTicketsRequest { get; set; }
    }
}