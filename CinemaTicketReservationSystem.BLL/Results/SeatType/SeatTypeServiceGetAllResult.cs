using System.Collections.Generic;
using CinemaTicketReservationSystem.BLL.Domain.SeatTypeModels;

namespace CinemaTicketReservationSystem.BLL.Results.SeatType
{
    public class SeatTypeServiceGetAllResult : Result
    {
        public IEnumerable<SeatTypeModel> SeatTypeModels { get; set; }
    }
}