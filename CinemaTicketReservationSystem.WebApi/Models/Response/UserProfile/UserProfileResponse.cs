using CinemaTicketReservationSystem.WebApi.Models.ViewModels.User;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.UserProfile
{
    public class UserProfileResponse : Response
    {
        public UserProfileViewModel UserProfileViewModel { get; set; }
    }
}