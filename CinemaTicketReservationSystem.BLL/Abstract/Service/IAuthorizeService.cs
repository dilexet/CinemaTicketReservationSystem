using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Authorize;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IAuthorizeService
    {
        Task<AuthorizeResult> LoginAsync(LoginModel loginModel);

        Task<AuthorizeResult> RegisterAsync(RegisterModel registerModel);

        Task<AuthorizeResult> RefreshTokenAsync(string username, string refreshToken);
    }
}