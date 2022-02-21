using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Models.Results.User;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public UserManagementService(IUserRepository userRepository, IRepository<Role> roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<UserServiceGetUsersResult> GetUsers()
        {
            var users = _userRepository.GetBy();

            var usersModel = _mapper.Map<IEnumerable<UserModel>>(await users.ToListAsync());

            return new UserServiceGetUsersResult()
            {
                Success = true,
                UserModels = usersModel
            };
        }

        public async Task<UserServiceResult> GetById(Guid id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            UserModel userModel = _mapper.Map<UserModel>(user);

            return new UserServiceResult()
            {
                Success = true,
                UserModel = userModel
            };
        }

        public async Task<UserServiceResult> CreateUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            user.PasswordHash = _userRepository.HashPassword(userModel.Password);
            var role = await _roleRepository.FindByIdAsync(userModel.RoleModel.Id);
            user.Role = role;

            user.UserProfile = new UserProfile
            {
                Name = user.Name
            };

            if (!await _userRepository.CreateAsync(user))
            {
                return new UserServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            UserModel newUserModel = _mapper.Map<UserModel>(user);

            return new UserServiceResult()
            {
                Success = true,
                UserModel = newUserModel
            };
        }

        public async Task<UserServiceResult> UpdateUser(Guid id, UserModel userModel)
        {
            var userExist = await _userRepository.FindByIdAsync(id);
            var roleExist = await _roleRepository.FindByIdAsync(userModel.RoleModel.Id);

            userExist.Name = userModel.Name;
            userExist.Email = userModel.Email;
            userExist.Role = roleExist;

            if (!await _userRepository.UpdateAsync(userExist))
            {
                return new UserServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            UserModel newUserModel = _mapper.Map<UserModel>(userExist);

            return new UserServiceResult()
            {
                Success = true,
                UserModel = newUserModel
            };
        }

        public async Task<UserServiceRemoveResult> DeleteUser(Guid id)
        {
            var userExist = await _userRepository.FindByIdAsync(id);

            if (!await _userRepository.RemoveAndSaveAsync(userExist))
            {
                return new UserServiceRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while removing to the database"
                    }
                };
            }

            return new UserServiceRemoveResult()
            {
                Success = true,
                Id = id
            };
        }
    }
}