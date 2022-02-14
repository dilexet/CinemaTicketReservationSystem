using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.BookingModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Booking;
using CinemaTicketReservationSystem.BLL.Models.Results.Session;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.BookingEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;
using CinemaTicketReservationSystem.DAL.Enums;
using Microsoft.Extensions.Caching.Memory;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<BookedOrder> _bookedOrderRepository;
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IRepository<SessionAdditionalService> _sessionAdditionalServiceRepository;
        private readonly IRepository<SessionSeat> _sessionSeatRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public BookingService(
            IRepository<Session> sessionRepository,
            IRepository<SessionAdditionalService> sessionAdditionalServiceRepository,
            IRepository<SessionSeat> sessionSeatRepository,
            IMapper mapper,
            IRepository<UserProfile> userProfileRepository,
            IRepository<BookedOrder> bookedOrderRepository,
            IMemoryCache memoryCache)
        {
            _sessionRepository = sessionRepository;
            _sessionAdditionalServiceRepository = sessionAdditionalServiceRepository;
            _sessionSeatRepository = sessionSeatRepository;
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _bookedOrderRepository = bookedOrderRepository;
            _memoryCache = memoryCache;
        }

        public async Task<BookingServiceResult> BookTickets(Guid id, BookingModel bookingModel)
        {
            var sessionExist = await _sessionRepository.FindByIdAsync(id);

            List<SessionAdditionalService> sessionAdditionalServices = new List<SessionAdditionalService>();
            double totalPrice = 0;
            foreach (var serviceId in bookingModel.SessionAdditionalServicesId)
            {
                var service = await _sessionAdditionalServiceRepository.FindByIdAsync(serviceId);
                totalPrice += service.Price;
                sessionAdditionalServices.Add(service);
            }

            List<SessionSeat> sessionSeats = new List<SessionSeat>();
            foreach (var seatId in bookingModel.SessionSeatsId)
            {
                var seat = await _sessionSeatRepository.FindByIdAsync(seatId);
                seat.TicketState = TicketState.Booked;
                totalPrice += seat.SessionSeatType.Price;
                sessionSeats.Add(seat);
            }

            var userExist = await _userProfileRepository.FindByIdAsync(bookingModel.UserProfileId);
            var bookedOrder = new BookedOrder()
            {
                TotalPrice = totalPrice,
                UserProfile = userExist,
                ReservedSessionSeats = sessionSeats,
                SelectedSessionAdditionalServices = sessionAdditionalServices
            };

            if (!await _bookedOrderRepository.CreateAsync(bookedOrder))
            {
                return new BookingServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            userExist.Tickets.ToList().Add(bookedOrder);

            if (!await _userProfileRepository.UpdateAsync(userExist))
            {
                return new BookingServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            var bookedOrderModel = _mapper.Map<BookedOrderModel>(bookedOrder);
            bookedOrderModel.Session = _mapper.Map<SessionModel>(sessionExist);

            return new BookingServiceResult()
            {
                Success = true,
                BookedOrder = bookedOrderModel
            };
        }

        public async Task<SessionServiceResult> GetSessionById(Guid id)
        {
            var session = await _sessionRepository.FindByIdAsync(id);

            if (session.StartDate <= DateTime.Now)
            {
                return new SessionServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Session ended"
                    }
                };
            }

            foreach (var seat in session.SessionSeats)
            {
                var seatId = _memoryCache.Get(seat.SeatId);
                if (seatId != null)
                {
                    seat.TicketState = TicketState.Blocked;
                }
            }

            var sessionModel = _mapper.Map<SessionModel>(session);

            return new SessionServiceResult()
            {
                Success = true,
                Session = sessionModel
            };
        }
    }
}