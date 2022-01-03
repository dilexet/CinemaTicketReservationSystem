using System;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;

namespace CinemaTicketReservationSystem.BLL.Abstract.Utils
{
    public interface IRefreshTokenService
    {
        RefreshToken Generate(string tokenId, Guid userId);

        bool Validate(RefreshToken refreshToken);
    }
}