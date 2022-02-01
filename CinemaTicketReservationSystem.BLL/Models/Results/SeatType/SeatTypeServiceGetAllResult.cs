using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels;

namespace CinemaTicketReservationSystem.BLL.Models.Results.SeatType
{
    public class SeatTypeServiceGetAllResult : Result
    {
        public IEnumerable<SeatTypeModel> SeatTypesList { get; set; }
    }
}