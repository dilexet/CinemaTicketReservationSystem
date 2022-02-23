using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract.Service;
using CinemaTicketReservationSystem.BLL.Abstract.Utils;
using CinemaTicketReservationSystem.BLL.Models.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Authorize;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.DAL.Entity.UserEntity;
using CinemaTicketReservationSystem.DAL.Enums;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthorizeService(
            IUserRepository userRepository,
            IRepository<Role> roleRepository,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<AuthorizeResult> LoginAsync(LoginModel loginModel)
        {
            var userExisting = await _userRepository.FirstOrDefaultAsync(x =>
                x.Email.Equals(loginModel.Name) || x.Name.Equals(loginModel.Name));

            var tokenResult = await _tokenService.GenerateTokens(_mapper.Map<TokenUserModel>(userExisting));
            if (!tokenResult.Success)
            {
                return new AuthorizeResult
                {
                    Success = false,
                    Errors = tokenResult.Errors
                };
            }

            userExisting.RefreshTokens.ToList().Add(tokenResult.RefreshToken);
            if (!await _userRepository.UpdateAsync(userExisting))
            {
                return new AuthorizeResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            return new AuthorizeResult
            {
                Success = true,
                JwtToken = tokenResult.JwtToken,
                RefreshToken = tokenResult.RefreshToken.Token
            };
        }

        public async Task<AuthorizeResult> RegisterAsync(RegisterModel registerModel)
        {
            User user = _mapper.Map<User>(registerModel);
            user.UserProfile = new UserProfile
            {
                Name = user.Name
            };
            user.PasswordHash = _userRepository.HashPassword(registerModel.Password);

            if (await _userRepository.FirstOrDefaultAsync() == null)
            {
                user.Role = await _roleRepository.FirstOrDefaultAsync(x => x.Name.Equals(RoleTypes.Admin.ToString()));
            }
            else
            {
                user.Role = await _roleRepository.FirstOrDefaultAsync(x => x.Name.Equals(RoleTypes.User.ToString()));
            }

            if (!await _userRepository.CreateAsync(user))
            {
                return new AuthorizeResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            var tokenResult = await _tokenService.GenerateTokens(_mapper.Map<TokenUserModel>(user));
            if (!tokenResult.Success)
            {
                return new AuthorizeResult
                {
                    Success = false,
                    Errors = tokenResult.Errors
                };
            }

            user.RefreshTokens.ToList().Add(tokenResult.RefreshToken);

            if (!await _userRepository.UpdateAsync(user))
            {
                return new AuthorizeResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            return new AuthorizeResult
            {
                Success = true,
                JwtToken = tokenResult.JwtToken,
                RefreshToken = tokenResult.RefreshToken.Token
            };
        }

        public async Task<AuthorizeResult> RefreshTokenAsync(Guid userId, string refreshToken)
        {
            var userExisting = await _userRepository.FindByIdAsync(userId);

            var token = userExisting.RefreshTokens.FirstOrDefault(x => x.Token.Equals(refreshToken));

            var refreshTokenResult =
                await _tokenService.RefreshJwtToken(_mapper.Map<TokenUserModel>(userExisting), token);

            if (!refreshTokenResult.Success)
            {
                return new AuthorizeResult
                {
                    Success = false,
                    Errors = refreshTokenResult.Errors
                };
            }

            return new AuthorizeResult
            {
                Success = true,
                JwtToken = refreshTokenResult.JwtToken,
                RefreshToken = refreshTokenResult.RefreshToken.Token
            };
        }
    }
}