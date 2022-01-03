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
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Cinema> _cinemaRepository;

        private readonly IRepository<SessionAdditionalService> _sessionAdditionalServiceRepository;
        private readonly IRepository<SessionSeatType> _sessionSeatTypeRepository;
        private readonly IRepository<SessionSeat> _sessionSeatRepository;

        private readonly IMapper _mapper;

        public SessionService(
            IRepository<Session> sessionRepository,
            IRepository<Movie> movieRepository,
            IRepository<Cinema> cinemaRepository,
            IMapper mapper,
            IRepository<SessionAdditionalService> sessionAdditionalServiceRepository,
            IRepository<SessionSeatType> sessionSeatTypeRepository,
            IRepository<SessionSeat> sessionSeatRepository)
        {
            _sessionRepository = sessionRepository;
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
            _sessionAdditionalServiceRepository = sessionAdditionalServiceRepository;
            _sessionSeatTypeRepository = sessionSeatTypeRepository;
            _sessionSeatRepository = sessionSeatRepository;
        }

        public async Task<SessionServiceResult> AddSession(SessionRequestModel sessionModel)
        {
            var cinemaExist =
                await _cinemaRepository.FirstOrDefaultAsync(cinema => cinema.Name.Equals(sessionModel.CinemaName));

            var hallExist = cinemaExist.Halls.FirstOrDefault(hall => hall.Name.Equals(sessionModel.HallName));

            var movieExist =
                await _movieRepository.FirstOrDefaultAsync(movie => movie.Name.Equals(sessionModel.MovieName));

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
            foreach (var row in hallExist!.Rows)
            {
                foreach (var seat in row.Seats)
                {
                    var sessionSeatTypeExist = sessionSeatTypes.FirstOrDefault(x => x.SeatType.Equals(seat.SeatType));
                    sessionSeats.Add(new SessionSeat()
                    {
                        Seat = seat,
                        SessionSeatType = sessionSeatTypeExist
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

        public async Task<SessionServiceResult> UpdateSessionInfo(Guid id, SessionRequestModel sessionModel)
        {
            var sessionExist = await _sessionRepository.FindByIdAsync(id);
            if (sessionExist == null)
            {
                return new SessionServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Session is not exists"
                    }
                };
            }

            var cinemaExist =
                await _cinemaRepository.FirstOrDefaultAsync(cinema => cinema.Name.Equals(sessionModel.CinemaName));

            var hallExist = cinemaExist.Halls.FirstOrDefault(hall => hall.Name.Equals(sessionModel.HallName));

            var movieExist =
                await _movieRepository.FirstOrDefaultAsync(movie => movie.Name.Equals(sessionModel.MovieName));

            foreach (var sessionAdditionalService in sessionExist.SessionAdditionalServices)
            {
                _sessionAdditionalServiceRepository.Remove(sessionAdditionalService);
            }

            foreach (var sessionSeat in sessionExist.SessionSeats)
            {
                _sessionSeatRepository.Remove(sessionSeat);
            }

            foreach (var sessionSeatType in sessionExist.SessionSeatType)
            {
                _sessionSeatTypeRepository.Remove(sessionSeatType);
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
            foreach (var row in hallExist!.Rows)
            {
                foreach (var seat in row.Seats)
                {
                    var sessionSeatTypeExist = sessionSeatTypes.FirstOrDefault(x => x.SeatType.Equals(seat.SeatType));
                    sessionSeats.Add(new SessionSeat()
                    {
                        Seat = seat,
                        SessionSeatType = sessionSeatTypeExist
                    });
                }
            }

            sessionExist.StartDate = sessionModel.StartDate;
            sessionExist.Movie = movieExist;
            sessionExist.Hall = hallExist;

            sessionExist.SessionAdditionalServices = sessionAdditionalServices;
            sessionExist.SessionSeatType = sessionSeatTypes;
            sessionExist.SessionSeats = sessionSeats;

            if (!await _sessionRepository.UpdateAsync(sessionExist))
            {
                return new SessionServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            SessionModel newSessionModel = _mapper.Map<SessionModel>(sessionExist);

            return new SessionServiceResult()
            {
                Success = true,
                Session = newSessionModel
            };
        }

        public async Task<SessionServiceRemoveResult> RemoveSession(Guid id)
        {
            var sessionExist = await _sessionRepository.FindByIdAsync(id);
            if (sessionExist == null)
            {
                return new SessionServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Session is not exists"
                    }
                };
            }

            if (!await _sessionRepository.RemoveAndSaveAsync(sessionExist))
            {
                return new SessionServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while removing to the database"
                    }
                };
            }

            return new SessionServiceRemoveResult()
            {
                Success = true,
                Id = id
            };
        }

        public async Task<SessionServiceGetAllResult> GetSessions()
        {
            IQueryable<Session> sessions = _sessionRepository.GetBy();

            if (sessions == null || !sessions.Any())
            {
                return new SessionServiceGetAllResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "No sessions found"
                    }
                };
            }

            var sessionsModel = _mapper.Map<IEnumerable<SessionModel>>(await sessions.ToListAsync());

            return new SessionServiceGetAllResult()
            {
                Success = true,
                Sessions = sessionsModel
            };
        }

        public async Task<SessionServiceResult> GetSessionById(Guid id)
        {
            var session = await _sessionRepository.FindByIdAsync(id);
            if (session == null)
            {
                return new SessionServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Session is not exists"
                    }
                };
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