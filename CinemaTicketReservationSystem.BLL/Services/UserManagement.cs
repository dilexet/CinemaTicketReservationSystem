using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract;
using CinemaTicketReservationSystem.BLL.Domain.UserModels;
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

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = await _userRepository.GetBy().ToListAsync();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            user.PasswordHash = _userRepository.HashPassword(userModel.Password);
            if (!await _userRepository.CreateAsync(user))
            {
                return null;
            }

            var role = await _roleRepository.FirstOrDefaultAsync(role => role.Name == userModel.RoleModel.Name);
            if (role == null)
            {
                return null;
            }

            user.Role = role;
            if (await _userRepository.UpdateAsync(user))
            {
                return userModel;
            }

            return null;
        }

        public async Task<UserModel> UpdateUser(UserModel userModel)
        {
            var userExist = await _userRepository.FirstOrDefaultAsync(user => user.Name == userModel.Name);
            if (userExist == null)
            {
                return null;
            }

            var result = await _userRepository.UpdateAsync(userExist);
            if (result)
            {
                return userModel;
            }

            return null;
        }

        public Task<UserModel> DeleteUser(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }
    }
}