using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserProfile
{
    public class UserProfileUpdateRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public UserProfileUpdateRequest UserProfileUpdateRequest { get; set; }
    }
}