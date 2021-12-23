using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.UserManagement
{
    public class UserManagementGetUsersResponse : Response
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}