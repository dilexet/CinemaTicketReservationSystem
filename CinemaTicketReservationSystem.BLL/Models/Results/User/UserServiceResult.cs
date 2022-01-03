using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.User
{
    public class UserServiceResult : Result
    {
        public UserModel UserModel { get; set; }
    }
}