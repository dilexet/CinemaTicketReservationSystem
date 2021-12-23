using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Results;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;

namespace CinemaTicketReservationSystem.BLL.Abstract.Utils
{
    public interface ITokenService
    {
        Task<TokenResult> GenerateTokens(TokenUserModel tokenUserModel);

        Task<TokenResult> RefreshJwtToken(TokenUserModel tokenUserModel, RefreshToken refreshToken);
    }
}