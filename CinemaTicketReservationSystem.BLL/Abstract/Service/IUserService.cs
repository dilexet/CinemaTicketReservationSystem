using System;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Filters;
using CinemaTicketReservationSystem.BLL.Results.User;

namespace CinemaTicketReservationSystem.BLL.Abstract.Service
{
    public interface IUserService
    {
        Task<UserServiceGetUsersResult> GetUsers(FilterParametersModel filter);

        Task<UserServiceResult> GetById(Guid id);

        Task<UserServiceResult> CreateUser(UserModel userModel);

        Task<UserServiceResult> UpdateUser(Guid id, UserModel userModel);

        Task<UserServiceRemoveResult> DeleteUser(Guid id);
    }
}