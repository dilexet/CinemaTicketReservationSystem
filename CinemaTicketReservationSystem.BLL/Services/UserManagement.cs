using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Results;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class UserManagement : IUserManagement
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserManagement(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<UserManagementGetUsersResult> GetUsers()
        {
            var users = await _userRepository.GetBy().ToListAsync();

            IEnumerable<UserModel> usersModel;
            try
            {
                usersModel = _mapper.Map<IEnumerable<UserModel>>(users);
            }
            catch (AutoMapperMappingException e)
            {
                return new UserManagementGetUsersResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        e.Message
                    }
                };
            }

            return new UserManagementGetUsersResult()
            {
                Success = true,
                UserModels = usersModel
            };
        }

        public async Task<UserManagementResult> CreateUser(UserModel userModel)
        {
            var userExist = await _userRepository.FirstOrDefaultAsync(x => x.Name == userModel.Name);
            if (userExist != null)
            {
                return new UserManagementResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "User is exists"
                    }
                };
            }

            var user = _mapper.Map<User>(userModel);
            user.PasswordHash = _userRepository.HashPassword(userModel.Password);
            var role = await _roleRepository.FirstOrDefaultAsync(role => role.Name == userModel.RoleModel.Name);
            if (role == null)
            {
                return new UserManagementResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Role is not exists"
                    }
                };
            }

            user.Role = role;
            if (!await _userRepository.CreateAsync(user))
            {
                return new UserManagementResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            UserModel newUserModel;
            try
            {
                newUserModel = _mapper.Map<UserModel>(user);
            }
            catch (AutoMapperMappingException e)
            {
                return new UserManagementResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        e.Message
                    }
                };
            }

            return new UserManagementResult()
            {
                Success = true,
                UserModel = newUserModel
            };
        }

        public async Task<UserManagementResult> UpdateUser(Guid id, UserModel userModel)
        {
            var userExist = await _userRepository.FindByIdAsync(id);
            if (userExist == null)
            {
                return new UserManagementResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "User is not exists"
                    }
                };
            }

            var roleExist = await _roleRepository.FirstOrDefaultAsync(role => role.Name == userModel.RoleModel.Name);
            if (roleExist == null)
            {
                return new UserManagementResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Role is not exists"
                    }
                };
            }

            userExist.Name = userModel.Name;
            userExist.Email = userModel.Email;
            userExist.Role = roleExist;

            if (!await _userRepository.UpdateAsync(userExist))
            {
                return new UserManagementResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            UserModel newUserModel;
            try
            {
                newUserModel = _mapper.Map<UserModel>(userExist);
            }
            catch (AutoMapperMappingException e)
            {
                return new UserManagementResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        e.Message
                    }
                };
            }

            return new UserManagementResult()
            {
                Success = true,
                UserModel = newUserModel
            };
        }

        public async Task<UserManagementRemoveResult> DeleteUser(Guid id)
        {
            var userExist = await _userRepository.FindByIdAsync(id);
            if (userExist == null)
            {
                return new UserManagementRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "User is not exists"
                    }
                };
            }

            if (!await _userRepository.RemoveAsync(userExist))
            {
                return new UserManagementRemoveResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while removing to the database"
                    }
                };
            }

            return new UserManagementRemoveResult()
            {
                Success = true,
                Id = id
            };
        }
    }
}