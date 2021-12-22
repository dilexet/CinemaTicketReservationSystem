using System.Collections.Generic;
using CinemaTicketReservationSystem.WebApi.Models.ViewModels;

namespace CinemaTicketReservationSystem.WebApi.Models.Response
{
    public class UserManagementGetUsersResponse : Response
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}