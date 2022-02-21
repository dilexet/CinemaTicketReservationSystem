namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema
{
    public class CinemaRequest
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}