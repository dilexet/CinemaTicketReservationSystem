using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserManagement
{
    public class CreateUserRequestWrapper
    {
        [FromBody]
        public UserCreateRequest UserCreateRequest { get; set; }
    }
}