using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.HallModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Hall;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class HallService : IHallService
    {
        private readonly IRepository<Cinema> _cinemaRepository;
        private readonly IRepository<Hall> _hallRepository;
        private readonly IMapper _mapper;

        public HallService(IRepository<Hall> hallRepository, IRepository<Cinema> cinemaRepository, IMapper mapper)
        {
            _hallRepository = hallRepository;
            _mapper = mapper;
            _cinemaRepository = cinemaRepository;
        }

        public async Task<HallServiceResult> AddHall(Guid cinemaId, HallModel hallModel)
        {
            var cinemaExist = await _cinemaRepository.FindByIdAsync(cinemaId);
            if (cinemaExist == null)
            {
                return new HallServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Cinema is not exists"
                    }
                };
            }

            if (cinemaExist.Halls.FirstOrDefault(x => x.Name == hallModel.Name) != null)
            {
                return new HallServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Hall with this name is exists"
                    }
                };
            }

            var hall = _mapper.Map<Hall>(hallModel);
            hall.Cinema = cinemaExist;

            List<string> seatTypes = new List<string>();
            hall.Rows.ToList()
                .ForEach(row => row.Seats.ToList().ForEach(seat => seatTypes.Add(seat.SeatType)));
            hall.SeatTypes = seatTypes.Distinct();

            if (!await _hallRepository.CreateAsync(hall))
            {
                return new HallServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            HallModel newHallModel = _mapper.Map<HallModel>(hall);

            return new HallServiceResult()
            {
                Success = true,
                HallModel = newHallModel
            };
        }

        public async Task<HallServiceResult> UpdateHall(Guid id, HallModel hallModel)
        {
            var hallExist = await _hallRepository.FindByIdAsync(id);
            if (hallExist == null)
            {
                return new HallServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Hall is not exists"
                    }
                };
            }

            var cinema = hallExist.Cinema;
            if (!await _hallRepository.RemoveAndSaveAsync(hallExist))
            {
                return new HallServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while removing to the database"
                    }
                };
            }

            var newHall = _mapper.Map<Hall>(hallModel);
            newHall.Cinema = cinema;

            List<string> seatTypes = new List<string>();
            newHall.Rows.ToList()
                .ForEach(row => row.Seats.ToList().ForEach(seat => seatTypes.Add(seat.SeatType)));
            newHall.SeatTypes = seatTypes.Distinct();

            if (!await _hallRepository.CreateAsync(newHall))
            {
                return new HallServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            HallModel newHallModel = _mapper.Map<HallModel>(newHall);

            return new HallServiceResult()
            {
                Success = true,
                HallModel = newHallModel
            };
        }

        public async Task<HallServiceRemoveResult> RemoveHall(Guid id)
        {
            var hallExist = await _hallRepository.FindByIdAsync(id);
            if (hallExist == null)
            {
                return new HallServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Hall is not exists"
                    }
                };
            }

            if (!await _hallRepository.RemoveAndSaveAsync(hallExist))
            {
                return new HallServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while removing to the database"
                    }
                };
            }

            return new HallServiceRemoveResult()
            {
                Success = true,
                Id = id
            };
        }

        public async Task<HallServiceGetAllResult> GetHalls()
        {
            IQueryable<Hall> halls = _hallRepository.GetBy();

            if (halls == null || !halls.Any())
            {
                return new HallServiceGetAllResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "No halls found"
                    }
                };
            }

            var hallsModel = _mapper.Map<IEnumerable<HallModel>>(await halls.ToListAsync());

            return new HallServiceGetAllResult()
            {
                Success = true,
                HallModels = hallsModel
            };
        }

        public async Task<HallServiceResult> GetHallById(Guid id)
        {
            var hall = await _hallRepository.FindByIdAsync(id);
            if (hall == null)
            {
                return new HallServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Hall is not exists"
                    }
                };
            }

            var hallModel = _mapper.Map<HallModel>(hall);

            return new HallServiceResult()
            {
                Success = true,
                HallModel = hallModel
            };
        }
    }
}