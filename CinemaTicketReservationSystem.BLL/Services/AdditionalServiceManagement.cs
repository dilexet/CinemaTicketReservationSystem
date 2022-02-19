using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.AdditionalServiceModels;
using CinemaTicketReservationSystem.BLL.Models.Results.AdditionalService;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class AdditionalServiceManagement : IAdditionalServiceManagement
    {
        private readonly IRepository<Cinema> _cinemaRepository;
        private readonly IRepository<AdditionalService> _additionalServiceRepository;
        private readonly IMapper _mapper;

        public AdditionalServiceManagement(
            IRepository<AdditionalService> additionalServiceRepository,
            IRepository<Cinema> cinemaRepository,
            IMapper mapper)
        {
            _additionalServiceRepository = additionalServiceRepository;
            _mapper = mapper;
            _cinemaRepository = cinemaRepository;
        }

        public async Task<AdditionalServiceResult> AddAdditionalService(
            Guid cinemaId, AdditionalServiceModel additionalServiceModel)
        {
            var cinemaExist = await _cinemaRepository.FindByIdAsync(cinemaId);

            var additionalService = _mapper.Map<AdditionalService>(additionalServiceModel);
            additionalService.Cinema = cinemaExist;
            if (!await _additionalServiceRepository.CreateAsync(additionalService))
            {
                return new AdditionalServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            AdditionalServiceModel newAdditionalServiceModel = _mapper.Map<AdditionalServiceModel>(additionalService);

            return new AdditionalServiceResult()
            {
                Success = true,
                AdditionalServiceModel = newAdditionalServiceModel
            };
        }

        public async Task<AdditionalServiceResult> UpdateAdditionalService(
            Guid id,
            AdditionalServiceModel additionalServiceModel)
        {
            var additionalServicesExist = await _additionalServiceRepository.FindByIdAsync(id);

            additionalServicesExist.Name = additionalServiceModel.Name;

            if (!await _additionalServiceRepository.UpdateAsync(additionalServicesExist))
            {
                return new AdditionalServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            AdditionalServiceModel newAdditionalService = _mapper.Map<AdditionalServiceModel>(additionalServicesExist);

            return new AdditionalServiceResult()
            {
                Success = true,
                AdditionalServiceModel = newAdditionalService
            };
        }

        public async Task<AdditionalServiceRemoveResult> RemoveAdditionalService(Guid id)
        {
            var additionalServiceExist = await _additionalServiceRepository.FindByIdAsync(id);

            if (!await _additionalServiceRepository.RemoveAndSaveAsync(additionalServiceExist))
            {
                return new AdditionalServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while removing to the database"
                    }
                };
            }

            return new AdditionalServiceRemoveResult()
            {
                Success = true,
                Id = id
            };
        }

        public async Task<AdditionalServiceGetAllResult> GetAdditionalServices()
        {
            IQueryable<AdditionalService> additionalServices = _additionalServiceRepository.GetBy();

            var additionalServicesModel =
                _mapper.Map<IEnumerable<AdditionalServiceModel>>(await additionalServices.ToListAsync());

            return new AdditionalServiceGetAllResult()
            {
                Success = true,
                AdditionalServices = additionalServicesModel
            };
        }

        public async Task<AdditionalServiceResult> GetAdditionalServiceById(Guid id)
        {
            var additionalService = await _additionalServiceRepository.FindByIdAsync(id);

            var additionalServiceModel = _mapper.Map<AdditionalServiceModel>(additionalService);

            return new AdditionalServiceResult()
            {
                Success = true,
                AdditionalServiceModel = additionalServiceModel
            };
        }

        public async Task<AdditionalServiceGetAllResult> GetAdditionalServicesByCinemaId(Guid cinemaId)
        {
            IQueryable<AdditionalService> additionalServices =
                _additionalServiceRepository.GetBy().Where(x => x.CinemaId.Equals(cinemaId));

            var additionalServiceModels =
                _mapper.Map<IEnumerable<AdditionalServiceModel>>(await additionalServices.ToListAsync());

            return new AdditionalServiceGetAllResult()
            {
                Success = true,
                AdditionalServices = additionalServiceModels
            };
        }
    }
}