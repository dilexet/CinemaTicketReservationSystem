using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;

namespace CinemaTicketReservationSystem.BLL.Results.User
{
    public class UserServiceGetUsersResult : Result
    {
        public IEnumerable<UserModel> UserModels { get; set; }
    }
}