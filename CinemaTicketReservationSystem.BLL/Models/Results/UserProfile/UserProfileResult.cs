using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.UserProfile
{
    public class UserProfileResult : Result
    {
        public UserProfileModel UserProfile { get; set; }
    }
}