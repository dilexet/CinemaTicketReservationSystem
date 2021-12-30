using CinemaTicketReservationSystem.BLL.Models.Results.SeatType;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface ISeatTypeService
    {
        SeatTypeServiceGetAllResult GetSeatTypes();
    }
}