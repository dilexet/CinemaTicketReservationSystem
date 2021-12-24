using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;

namespace CinemaTicketReservationSystem.BLL.Results
{
    public class UserManagementGetUsersResult : Result
    {
        public IEnumerable<UserModel> UserModels { get; set; }
    }
}