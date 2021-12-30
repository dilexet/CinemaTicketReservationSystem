using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Authorize;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;

namespace CinemaTicketReservationSystem.BLL.Abstract.Utils
{
    public interface ITokenService
    {
        Task<TokenResult> GenerateTokens(TokenUserModel tokenUserModel);

        Task<TokenResult> RefreshJwtToken(TokenUserModel tokenUserModel, RefreshToken refreshToken);
    }
}