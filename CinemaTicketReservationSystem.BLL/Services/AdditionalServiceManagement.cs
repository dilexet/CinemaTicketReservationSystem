using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.AdditionalServiceModels;
using CinemaTicketReservationSystem.BLL.Results.AdditionalService;
using CinemaTicketReservationSystem.DAL.Abstract.Cinema;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class AdditionalServiceManagement : IAdditionalServiceManagement
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IAdditionalRepository _additionalServiceRepository;
        private readonly IMapper _mapper;

        public AdditionalServiceManagement(
            IAdditionalRepository additionalServiceRepository, ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _additionalServiceRepository = additionalServiceRepository;
            _mapper = mapper;
            _cinemaRepository = cinemaRepository;
        }

        public async Task<AdditionalServiceResult> AddAdditionalService(
            Guid cinemaId, AdditionalServiceModel additionalServiceModel)
        {
            var cinemaExist = await _cinemaRepository.FindByIdAsync(cinemaId);
            if (cinemaExist == null)
            {
                return new AdditionalServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Cinema is not exists"
                    }
                };
            }

            if (cinemaExist.AdditionalServices.FirstOrDefault(x => x.Name == additionalServiceModel.Name) != null)
            {
                return new AdditionalServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Additional service with this name is exists in this cinema"
                    }
                };
            }

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

        public async Task<AdditionalServiceResult> UpdateAdditionalService(Guid guid, Guid id, AdditionalServiceModel additionalServiceModel)
        {
            var additionalServicesExist = await _additionalServiceRepository.FindByIdAsync(id);
            if (additionalServicesExist == null)
            {
                return new AdditionalServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Additional service is not exists"
                    }
                };
            }

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
            if (additionalServiceExist == null)
            {
                return new AdditionalServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Additional Service is not exists"
                    }
                };
            }

            if (!await _additionalServiceRepository.RemoveAsync(additionalServiceExist))
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

            if (additionalServices == null || !additionalServices.Any())
            {
                return new AdditionalServiceGetAllResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "No additional service found"
                    }
                };
            }

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
            if (additionalService == null)
            {
                return new AdditionalServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Additional Service is not exists"
                    }
                };
            }

            var additionalServiceModel = _mapper.Map<AdditionalServiceModel>(additionalService);

            return new AdditionalServiceResult()
            {
                Success = true,
                AdditionalServiceModel = additionalServiceModel
            };
        }
    }
}