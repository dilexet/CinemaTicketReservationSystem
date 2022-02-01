using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Domain.AdditionalServiceModels;
using CinemaTicketReservationSystem.BLL.Models.Results.AdditionalService;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IAdditionalServiceManagement
    {
        Task<AdditionalServiceResult> AddAdditionalService(Guid cinemaId, AdditionalServiceModel additionalService);

        Task<AdditionalServiceResult> UpdateAdditionalService(Guid id, AdditionalServiceModel additionalService);

        Task<AdditionalServiceRemoveResult> RemoveAdditionalService(Guid id);

        Task<AdditionalServiceGetAllResult> GetAdditionalServices();

        Task<AdditionalServiceResult> GetAdditionalServiceById(Guid id);

        Task<AdditionalServiceGetAllResult> GetAdditionalServicesByCinemaId(Guid cinemaId);
    }
}