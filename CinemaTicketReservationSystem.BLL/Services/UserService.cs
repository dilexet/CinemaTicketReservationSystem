using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Models.Domain.UserModels;
using CinemaTicketReservationSystem.BLL.Models.FilterModel;
using CinemaTicketReservationSystem.BLL.Models.Results.User;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IRepository<Role> roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<UserServiceGetUsersResult> GetUsers(FilterParametersModel filter)
        {
            var users = _userRepository.GetBy();

            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                var searQuery = filter.SearchQuery.ToLower();
                users = users.Where(user =>
                    user.Name.ToLower().Contains(searQuery) ||
                    user.Email.ToLower().Contains(searQuery) ||
                    user.Role.Name.ToLower().Contains(searQuery));
            }

            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                switch (filter.SortBy)
                {
                    case "name":
                        users = users?.OrderBy(movie => movie.Name);
                        break;
                    case "role_name":
                        users = users?.OrderBy(movie => movie.Role.Name);
                        break;
                }
            }

            if (users == null || !users.Any())
            {
                return new UserServiceGetUsersResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "No users found"
                    }
                };
            }

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
            if (user == null)
            {
                return new UserServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "User is not exists"
                    }
                };
            }

            UserModel userModel = _mapper.Map<UserModel>(user);

            return new UserServiceResult()
            {
                Success = true,
                UserModel = userModel
            };
        }

        public async Task<UserServiceResult> CreateUser(UserModel userModel)
        {
            var userExist = await _userRepository.FirstOrDefaultAsync(x => x.Name == userModel.Name);
            if (userExist != null)
            {
                return new UserServiceResult()
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
                return new UserServiceResult()
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
            if (await _userRepository.FirstOrDefaultAsync(x => x.Name == userModel.Name) != null)
            {
                return new UserServiceResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "User with this name is exists"
                    }
                };
            }

            var userExist = await _userRepository.FindByIdAsync(id);
            if (userExist == null)
            {
                return new UserServiceResult()
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
                return new UserServiceResult()
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
            if (userExist == null)
            {
                return new UserServiceRemoveResult()
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