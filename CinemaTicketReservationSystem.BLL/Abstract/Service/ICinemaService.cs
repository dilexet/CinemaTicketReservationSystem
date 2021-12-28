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

        Task<CinemaServiceResult> AddAdditionalService(Guid cinemaId, AdditionalServiceModel additionalService);

        Task<CinemaServiceResult> UpdateAdditionalService(
            Guid id, Guid cinemaId, AdditionalServiceModel additionalService);

        Task<CinemaServiceResult> AddHall(Guid cinemaId, HallModel hall);

        Task<CinemaServiceResult> UpdateHall(Guid id, Guid cinemaId, HallModel hall);
    }
}