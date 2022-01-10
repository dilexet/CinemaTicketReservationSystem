using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.AdditionalService
{
    public class UpdateAdditionalServiceRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromRoute(Name = "cinemaId")]
        public Guid CinemaId { get; set; }

        [FromBody]
        public AdditionalServiceRequest AdditionalServiceRequest { get; set; }
    }
}