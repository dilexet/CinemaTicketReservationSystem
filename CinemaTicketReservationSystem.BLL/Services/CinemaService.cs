using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.CinemaModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Cinema;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly IRepository<Cinema> _cinemaRepository;
        private readonly IMapper _mapper;

        public CinemaService(IRepository<Cinema> cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<CinemaServiceResult> AddCinema(CinemaModel cinemaModel)
        {
            var cinemaExist = await _cinemaRepository.FirstOrDefaultAsync(x => x.Name == cinemaModel.Name);
            if (cinemaExist != null)
            {
                return new CinemaServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Cinema is exists"
                    }
                };
            }

            var cinema = _mapper.Map<Cinema>(cinemaModel);

            if (!await _cinemaRepository.CreateAsync(cinema))
            {
                return new CinemaServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            CinemaModel newCinemaModel = _mapper.Map<CinemaModel>(cinema);

            return new CinemaServiceResult()
            {
                Success = true,
                CinemaModel = newCinemaModel
            };
        }

        public async Task<CinemaServiceResult> UpdateCinemaInfo(Guid id, CinemaModel cinemaModel)
        {
            if (await _cinemaRepository.FirstOrDefaultAsync(x => x.Name == cinemaModel.Name) != null)
            {
                return new CinemaServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Cinema with this name is exists"
                    }
                };
            }

            var cinemaExist = await _cinemaRepository.FindByIdAsync(id);
            if (cinemaExist == null)
            {
                return new CinemaServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Cinema is not exists"
                    }
                };
            }

            cinemaExist.Name = cinemaModel.Name;
            cinemaExist.Address.Street = cinemaModel.AddressModel.Street;
            cinemaExist.Address.CityName = cinemaModel.AddressModel.CityName;

            if (!await _cinemaRepository.UpdateAsync(cinemaExist))
            {
                return new CinemaServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            CinemaModel newCinemaModel = _mapper.Map<CinemaModel>(cinemaExist);

            return new CinemaServiceResult()
            {
                Success = true,
                CinemaModel = newCinemaModel
            };
        }

        public async Task<CinemaServiceRemoveResult> RemoveCinema(Guid id)
        {
            var cinemaExist = await _cinemaRepository.FindByIdAsync(id);
            if (cinemaExist == null)
            {
                return new CinemaServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Cinema is not exists"
                    }
                };
            }

            if (!await _cinemaRepository.RemoveAndSaveAsync(cinemaExist))
            {
                return new CinemaServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while removing to the database"
                    }
                };
            }

            return new CinemaServiceRemoveResult()
            {
                Success = true,
                Id = id
            };
        }

        public async Task<CinemaServiceGetAllResult> GetCinemas()
        {
            IQueryable<Cinema> cinemas = _cinemaRepository.GetBy();

            if (cinemas == null || !cinemas.Any())
            {
                return new CinemaServiceGetAllResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "No cinemas found"
                    }
                };
            }

            var cinemasModel = _mapper.Map<IEnumerable<CinemaModel>>(await cinemas.ToListAsync());

            return new CinemaServiceGetAllResult()
            {
                Success = true,
                CinemaModels = cinemasModel
            };
        }

        public async Task<CinemaServiceResult> GetCinemaById(Guid id)
        {
            var cinema = await _cinemaRepository.FindByIdAsync(id);
            if (cinema == null)
            {
                return new CinemaServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Cinema is not exists"
                    }
                };
            }

            var cinemaModel = _mapper.Map<CinemaModel>(cinema);

            return new CinemaServiceResult()
            {
                Success = true,
                CinemaModel = cinemaModel
            };
        }
    }
}