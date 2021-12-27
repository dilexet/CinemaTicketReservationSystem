using System.Collections.Generic;

namespace CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema
{
    public class CinemaRequest
    {
        public string Name { get; set; }

        public string CityName { get; set; }

        public string Street { get; set; }

        public uint NumberOfHalls { get; set; }

        public IEnumerable<string> AdditionalServiceNames { get; set; }

        public IEnumerable<HallRequest> Halls { get; set; }
    }
}