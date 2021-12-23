using System.IdentityModel.Tokens.Jwt;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;

namespace CinemaTicketReservationSystem.BLL.Abstract.Utils
{
    public interface IJwtService
    {
        JwtSecurityToken Generate(TokenUserModel user);
    }
}