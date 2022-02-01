using System;

namespace CinemaTicketReservationSystem.WebApi.Models.Filters
{
    public class FilterParameters
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public bool? StillShowing { get; set; }
    }
}