using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.BLL.Models.Results.User;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IUserManagementService
    {
        Task<UserServiceGetUsersResult> GetUsers(FilterParametersModel filter);

        Task<UserServiceResult> GetById(Guid id);

        Task<UserServiceResult> CreateUser(UserModel userModel);

        Task<UserServiceResult> UpdateUser(Guid id, UserModel userModel);

        Task<UserServiceRemoveResult> DeleteUser(Guid id);
    }
}