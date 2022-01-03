using CinemaTicketReservationSystem.WebApi.Models.ViewModels.User;

namespace CinemaTicketReservationSystem.WebApi.Models.Response.UserManagement
{
    public class UserManagementResponse : Response
    {
        public UserViewModel User { get; set; }
    }
}