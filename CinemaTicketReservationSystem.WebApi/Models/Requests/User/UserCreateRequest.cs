using System.ComponentModel.DataAnnotations;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.User
{
    public class UserCreateRequest
    {
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string RoleName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}