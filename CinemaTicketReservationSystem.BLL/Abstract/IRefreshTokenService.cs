using System;
using CinemaTicketReservationSystem.DAL.Entity;

namespace CinemaTicketReservationSystem.BLL.Abstract
{
    public interface IRefreshTokenService
    {
        RefreshToken Generate(string tokenId, Guid userId);

        bool Validate(RefreshToken refreshToken);
    }
}