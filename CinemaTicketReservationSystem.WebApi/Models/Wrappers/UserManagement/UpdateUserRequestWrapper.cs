using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserManagement
{
    public class UpdateUserRequestWrapper
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public UserUpdateRequest UserUpdateRequest { get; set; }
    }
}