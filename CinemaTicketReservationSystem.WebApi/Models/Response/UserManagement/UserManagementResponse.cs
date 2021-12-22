using CinemaTicketReservationSystem.WebApi.Models.ViewModels;

namespace CinemaTicketReservationSystem.WebApi.Models.Response
{
    public class UserManagementResponse : Response
    {
        public UserViewModel User { get; set; }
    }
}