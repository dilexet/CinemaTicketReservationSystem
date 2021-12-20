﻿using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Results;
using CinemaTicketReservationSystem.DAL.Entity;
using System.Threading.Tasks;

namespace CinemaTicketReservationSystem.BLL.Abstract
{
    public interface ITokenService
    {
        Task<TokenResult> GenerateTokens(TokenUserModel tokenUserModel);

        Task<TokenResult> RefreshJwtToken(TokenUserModel tokenUserModel, RefreshToken refreshToken);
    }
}