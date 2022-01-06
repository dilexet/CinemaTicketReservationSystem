using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.AdditionalService
{
    public class AddAdditionalServiceRequestWrapper
    {
        [FromRoute(Name = "cinemaId")]
        public Guid CinemaId { get; set; }

        [FromBody]
        public AdditionalServiceRequest AdditionalServiceRequest { get; set; }
    }
}