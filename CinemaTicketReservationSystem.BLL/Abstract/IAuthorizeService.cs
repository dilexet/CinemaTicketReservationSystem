using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Results;

namespace CinemaTicketReservationSystem.BLL.Abstract
{
    public interface IAuthorizeService
    {
        Task<AuthorizeResult> LoginAsync(LoginModel loginModel);
        Task<AuthorizeResult> RegisterAsync(RegisterModel registerModel);
        Task<AuthorizeResult> RefreshTokenAsync(String username, String refreshToken);
    }
}