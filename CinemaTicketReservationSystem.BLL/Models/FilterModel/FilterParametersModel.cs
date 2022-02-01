using System;

namespace CinemaTicketReservationSystem.BLL.Models.FilterModel
{
    public class FilterParametersModel
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public bool? StillShowing { get; set; }
    }
}