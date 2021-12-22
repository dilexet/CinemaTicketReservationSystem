using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Results;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IUserManagement
    {
        Task<UserManagementGetUsersResult> GetUsers();

        Task<UserManagementResult> CreateUser(UserModel userModel);

        Task<UserManagementResult> UpdateUser(Guid id, UserModel userModel);

        Task<UserManagementRemoveResult> DeleteUser(Guid id);
    }
}