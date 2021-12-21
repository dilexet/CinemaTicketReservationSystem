using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;

namespace CinemaTicketReservationSystem.BLL.Abstract
{
    public interface IUserManagement
    {
        Task<IEnumerable<UserModel>> GetUsers();

        Task<UserModel> CreateUser(UserModel userModel);

        Task<UserModel> UpdateUser(UserModel userModel);

        Task<UserModel> DeleteUser(UserModel userModel);
    }
}