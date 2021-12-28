using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Results.SeatType;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface ISeatTypeService
    {
        Task<SeatTypeServiceGetAllResult> GetSeatTypes();
    }
}