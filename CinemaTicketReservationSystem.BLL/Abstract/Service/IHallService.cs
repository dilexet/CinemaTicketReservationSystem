using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.HallModels;
using CinemaTicketReservationSystem.BLL.Results.Hall;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IHallService
    {
        Task<HallServiceResult> AddHall(Guid cinemaId, HallModel hall);

        Task<HallServiceResult> UpdateHall(Guid id, HallModel hall);

        Task<HallServiceRemoveResult> RemoveHall(Guid id);

        Task<HallServiceGetAllResult> GetHalls();

        Task<HallServiceResult> GetHallById(Guid id);
    }
}