using CinemaTicketReservationSystem.DAL.Entity;
using System;

namespace CinemaTicketReservationSystem.BLL.Abstract
{
    public interface IRefreshTokenService
    {
        RefreshToken Generate(string tokenId, Guid userId);

        bool Validate(RefreshToken refreshToken);
    }
}