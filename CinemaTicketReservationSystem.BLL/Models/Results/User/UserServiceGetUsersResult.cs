using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.User
{
    public class UserServiceGetUsersResult : Result
    {
        public IEnumerable<UserModel> UserModels { get; set; }
    }
}