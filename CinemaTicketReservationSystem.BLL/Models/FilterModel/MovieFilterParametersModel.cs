using System;

namespace CinemaTicketReservationSystem.BLL.Models.FilterModel
{
    public class MovieFilterParametersModel
    {
        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public string CityName { get; set; }

        public DateTime? StartDate { get; set; }

        public uint NumberAvailableSeats { get; set; }
    }
}