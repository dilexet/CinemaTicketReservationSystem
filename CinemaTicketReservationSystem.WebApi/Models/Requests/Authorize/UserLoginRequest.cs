using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage = "User Name is required")]
        public String Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public String Password { get; set; }
    }
}