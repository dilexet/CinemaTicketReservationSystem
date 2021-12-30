using System;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Session;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> _sessionRepository;
        private readonly IMapper _mapper;

        public SessionService(IRepository<Session> sessionRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
        }

        public Task<SessionServiceResult> AddSession(SessionModel sessionModel)
        {
            throw new NotImplementedException();
        }

        public Task<SessionServiceResult> UpdateSessionInfo(Guid id, SessionModel sessionModel)
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