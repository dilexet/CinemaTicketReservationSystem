using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.CinemaModels;
using CinemaTicketReservationSystem.BLL.Results.Cinema;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface ICinemaService
    {
        Task<CinemaServiceResult> AddCinema(CinemaModel cinemaModel);

        Task<CinemaServiceResult> UpdateCinemaInfo(Guid id, CinemaModel cinema);

        Task<CinemaServiceRemoveResult> RemoveCinema(Guid id);

        Task<CinemaServiceGetAllResult> GetCinemas();

        Task<CinemaServiceResult> GetCinemaById(Guid id);
    }
}