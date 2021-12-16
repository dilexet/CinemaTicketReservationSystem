using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Results;
using CinemaTicketReservationSystem.DAL.Entity;

namespace CinemaTicketReservationSystem.BLL.Abstract
{
    public interface ITokenService
    {
        Task<TokenResult> GenerateTokens(TokenUserModel tokenUserModel);
        Task<TokenResult> RefreshJwtToken(TokenUserModel tokenUserModel, RefreshToken refreshToken);
    }
}