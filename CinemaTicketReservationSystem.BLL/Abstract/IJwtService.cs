using System.IdentityModel.Tokens.Jwt;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;

namespace CinemaTicketReservationSystem.BLL.Abstract
{
    public interface IJwtService
    {
        JwtSecurityToken Generate(TokenUserModel user);
    }
}