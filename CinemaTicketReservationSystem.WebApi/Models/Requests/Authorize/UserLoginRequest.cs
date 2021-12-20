namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize
{
    public class UserLoginRequest
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}