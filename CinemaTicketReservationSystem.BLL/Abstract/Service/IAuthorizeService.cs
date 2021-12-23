using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Results;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IAuthorizeService
    {
        Task<AuthorizeResult> LoginAsync(LoginModel loginModel);

        Task<AuthorizeResult> RegisterAsync(RegisterModel registerModel);

        Task<AuthorizeResult> RefreshTokenAsync(string username, string refreshToken);
    }
}