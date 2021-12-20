using CinemaTicketReservationSystem.BLL.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Results;
using System.Threading.Tasks;

namespace CinemaTicketReservationSystem.BLL.Abstract
{
    public interface IAuthorizeService
    {
        Task<AuthorizeResult> LoginAsync(LoginModel loginModel);

        Task<AuthorizeResult> RegisterAsync(RegisterModel registerModel);

        Task<AuthorizeResult> RefreshTokenAsync(string username, string refreshToken);
    }
}