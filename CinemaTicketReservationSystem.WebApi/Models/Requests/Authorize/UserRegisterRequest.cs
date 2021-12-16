using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize
{
    public class UserRegisterRequest
    {
        [Required(ErrorMessage = "User Name is required")]
        public String Name { get; set; }

        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address")]
        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public String ConfirmPassword { get; set; }
    }
}