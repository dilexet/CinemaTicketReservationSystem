using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Session;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Cinema> _cinemaRepository;
        private readonly IMapper _mapper;

        public SessionService(
            IRepository<Session> sessionRepository,
            IRepository<Movie> movieRepository,
            IRepository<Cinema> cinemaRepository,
            IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<SessionServiceResult> AddSession(SessionRequestModel sessionModel)
        {
            var cinemaExist =
                await _cinemaRepository.FirstOrDefaultAsync(cinema => cinema.Name.Equals(sessionModel.CinemaName));
            if (cinemaExist == null)
            {
                return new SessionServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Cinema is not exists"
                    }
                };
            }

            var hallExist = cinemaExist.Halls.FirstOrDefault(hall => hall.Name.Equals(sessionModel.HallName));

            if (hallExist == null)
            {
                return new SessionServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Hall is not exists in this cinema"
                    }
                };
            }

            var movieExist =
                await _movieRepository.FirstOrDefaultAsync(movie => movie.Name.Equals(sessionModel.MovieName));

            if (movieExist == null)
            {
                return new SessionServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Movie is not exists"
                    }
                };
            }

            List<SessionAdditionalService> sessionAdditionalServices = new List<SessionAdditionalService>();
            foreach (var sessionAdditionalService in sessionModel.SessionAdditionalServices)
            {
                var additionalServiceExist = cinemaExist.AdditionalServices.FirstOrDefault(service =>
                    service.Name.Equals(sessionAdditionalService.AdditionalService.Name));
                sessionAdditionalServices.Add(new SessionAdditionalService()
                {
                    AdditionalService = additionalServiceExist,
                    Price = sessionAdditionalService.Price
                });
            }

            List<SessionSeatType> sessionSeatTypes =
                _mapper.Map<List<SessionSeatType>>(sessionModel.SessionSeatTypes);

            List<SessionSeat> sessionSeats = new List<SessionSeat>();
            foreach (var row in hallExist.Rows)
            {
                foreach (var seat in row.Seats)
                {
                    sessionSeats.Add(new SessionSeat()
                    {
                        Seat = seat,
                        SessionSeatType = sessionSeatTypes.FirstOrDefault(x => x.SeatType.Equals(seat.SeatType))
                    });
                }
            }

            Session session = new Session
            {
                StartDate = sessionModel.StartDate,
                Movie = movieExist,
                Hall = hallExist,
                SessionAdditionalServices = sessionAdditionalServices,
                SessionSeatType = sessionSeatTypes,
                SessionSeats = sessionSeats
            };

            if (!await _sessionRepository.CreateAsync(session))
            {
                return new SessionServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            SessionModel newSessionModel = _mapper.Map<SessionModel>(session);

            return new SessionServiceResult()
            {
                Success = true,
                Session = newSessionModel
            };
        }

        public Task<SessionServiceResult> UpdateSessionInfo(Guid id, SessionRequestModel sessionModel)
        {
            throw new NotImplementedException();
        }

        public Task<SessionServiceRemoveResult> RemoveSession(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SessionServiceGetAllResult> GetSessions()
        {
            throw new NotImplementedException();
        }

        public Task<SessionServiceResult> GetSessionById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}