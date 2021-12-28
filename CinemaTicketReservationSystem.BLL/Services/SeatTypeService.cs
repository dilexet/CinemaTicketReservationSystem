using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.SeatTypeModels;
using CinemaTicketReservationSystem.BLL.Results.SeatType;
using CinemaTicketReservationSystem.DAL.Abstract.Cinema;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class SeatTypeService : ISeatTypeService
    {
        private readonly ISeatTypeRepository _seatTypeRepository;
        private readonly IMapper _mapper;

        public SeatTypeService(ISeatTypeRepository seatTypeRepository, IMapper mapper)
        {
            _seatTypeRepository = seatTypeRepository;
            _mapper = mapper;
        }

        public async Task<SeatTypeServiceGetAllResult> GetSeatTypes()
        {
            IQueryable<SeatType> seatTypes = _seatTypeRepository.GetBy();

            var seatTypeModels = _mapper.Map<IEnumerable<SeatTypeModel>>(await seatTypes.ToListAsync());

            return new SeatTypeServiceGetAllResult()
            {
                Success = true,
                SeatTypeModels = seatTypeModels
            };
        }
    }
}