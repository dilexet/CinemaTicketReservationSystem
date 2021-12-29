using CinemaTicketReservationSystem.BLL.Results.SeatType;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface ISeatTypeService
    {
        SeatTypeServiceGetAllResult GetSeatTypes();
    }
}