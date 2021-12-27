using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Filters;
using CinemaTicketReservationSystem.BLL.Results.UserManagement;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IUserManagement
    {
        Task<UserManagementGetUsersResult> GetUsers(FilterParametersModel filter);

        Task<UserManagementResult> GetById(Guid id);

        Task<UserManagementResult> CreateUser(UserModel userModel);

        Task<UserManagementResult> UpdateUser(Guid id, UserModel userModel);

        Task<UserManagementRemoveResult> DeleteUser(Guid id);
    }
}