using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize
{
    public class UserLoginRequest
    {
        public String Name { get; set; }
        public String Password { get; set; }
    }
}