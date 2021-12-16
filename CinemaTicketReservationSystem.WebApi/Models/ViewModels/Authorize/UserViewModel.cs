using System;

namespace CinemaTicketReservationSystem.WebApi.Models.ViewModels.Authorize
{
    public class UserViewModel
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Role { get; set; }
    }
}