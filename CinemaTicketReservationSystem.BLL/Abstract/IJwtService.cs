using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using System.IdentityModel.Tokens.Jwt;

namespace CinemaTicketReservationSystem.BLL.Abstract
{
    public interface IJwtService
    {
        JwtSecurityToken Generate(TokenUserModel user);
    }
}