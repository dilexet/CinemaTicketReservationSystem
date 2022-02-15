using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels.User;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.Role
{
    public class RoleManagementGetRolesResponse : Response
    {
        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}