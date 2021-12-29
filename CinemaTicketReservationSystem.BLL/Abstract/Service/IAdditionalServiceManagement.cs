using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.AdditionalServiceModels;
using CinemaTicketReservationSystem.BLL.Results.AdditionalService;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IAdditionalServiceManagement
    {
        Task<AdditionalServiceResult> AddAdditionalService(Guid cinemaId, AdditionalServiceModel additionalService);

        Task<AdditionalServiceResult> UpdateAdditionalService(Guid guid, Guid id, AdditionalServiceModel additionalService);

        Task<AdditionalServiceRemoveResult> RemoveAdditionalService(Guid id);

        Task<AdditionalServiceGetAllResult> GetAdditionalServices();

        Task<AdditionalServiceResult> GetAdditionalServiceById(Guid id);
    }
}