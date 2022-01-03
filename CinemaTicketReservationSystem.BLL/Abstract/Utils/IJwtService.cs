using System.IdentityModel.Tokens.Jwt;
using CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels;

namespace CinemaTicketReservationSystem.BLL.Abstract.Utils
{
    public interface IJwtService
    {
        JwtSecurityToken Generate(TokenUserModel user);
    }
}