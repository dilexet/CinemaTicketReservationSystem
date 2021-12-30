﻿using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Domain.SessionModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Session;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface ISessionService
    {
        Task<SessionServiceResult> AddSession(SessionModel sessionModel);

        Task<SessionServiceResult> UpdateSessionInfo(Guid id, SessionModel sessionModel);

        Task<SessionServiceRemoveResult> RemoveSession(Guid id);

        Task<SessionServiceGetAllResult> GetSessions();

        Task<SessionServiceResult> GetSessionById(Guid id);
    }
}