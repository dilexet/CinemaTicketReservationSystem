using System;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserProfile
{
    public class UserProfileGetRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromHeader]
        public bool ShowPastTicket { get; set; }
    }
}