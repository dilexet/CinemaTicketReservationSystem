using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaTicketReservationSystem.BLL.Abstract;
using CinemaTicketReservationSystem.BLL.Domain.AuthModels;
using CinemaTicketReservationSystem.BLL.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Results;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity;
using CinemaTicketReservationSystem.DAL.Enums;

namespace CinemaTicketReservationSystem.BLL.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthorizeService(IUserRepository userRepository, IRoleRepository roleRepository, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<AuthorizeResult> LoginAsync(LoginModel loginModel)
        {
            var userExisting = await _userRepository.SingleOrDefaultAsync(x =>
                x.Email.Equals(loginModel.Name) || x.Name.Equals(loginModel.Name));

            if (userExisting == null ||
                !_userRepository.CheckPassword(userExisting.PasswordHash, loginModel.Password))
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Invalid username or password"
                    }
                };
            }

            var tokenResult = await _tokenService.GenerateTokens(_mapper.Map<TokenUserModel>(userExisting));
            if (!tokenResult.Success)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        tokenResult.Error
                    }
                };
            }

            userExisting.RefreshTokens.ToList().Add(tokenResult.RefreshToken);
            if (!await _userRepository.Update(userExisting))
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            return new AuthorizeResult()
            {
                Success = true,
                JwtToken = tokenResult.JwtToken,
                RefreshToken = tokenResult.RefreshToken.Token
            };
        }

        public async Task<AuthorizeResult> RegisterAsync(RegisterModel registerModel)
        {
            var userExisting = await _userRepository.SingleOrDefaultAsync(x =>
                x.Email.Equals(registerModel.Email) || x.Name.Equals(registerModel.Name));
            if (userExisting != null)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "User is exists"
                    }
                };
            }

            User user = _mapper.Map<User>(registerModel);
            user.PasswordHash = _userRepository.HasPasswordAsync(registerModel.Password);

            if (await _userRepository.SingleOrDefaultAsync() == null)
            {
                user.Role = await _roleRepository.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.Admin.ToString()));
            }
            else
            {
                user.Role = await _roleRepository.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.User.ToString()));
            }

            if (!await _userRepository.CreateAsync(user))
            {
                return new AuthorizeResult()
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
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        tokenResult.Error
                    }
                };
            }

            user.RefreshTokens.ToList().Add(tokenResult.RefreshToken);

            if (!await _userRepository.Update(user))
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            return new AuthorizeResult()
            {
                Success = true,
                JwtToken = tokenResult.JwtToken,
                RefreshToken = tokenResult.RefreshToken.Token
            };
        }

        public async Task<AuthorizeResult> RefreshTokenAsync(string username, string refreshToken)
        {
            var userExisting = await _userRepository.SingleOrDefaultAsync(x =>
                x.Email.Equals(username) || x.Name.Equals(username));
            if (userExisting == null)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "User is not exists"
                    }
                };
            }

            var token = userExisting.RefreshTokens.FirstOrDefault(x => x.Token.Equals(refreshToken));
            if (token == null)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Token is not exists"
                    }
                };
            }

            var refreshTokenResult =
                await _tokenService.RefreshJwtToken(_mapper.Map<TokenUserModel>(userExisting), token);

            if (!refreshTokenResult.Success)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[]
                    {
                        refreshTokenResult.Error
                    }
                };
            }

            return new AuthorizeResult()
            {
                Success = true,
                JwtToken = refreshTokenResult.JwtToken,
                RefreshToken = refreshTokenResult.RefreshToken.Token
            };
        }
    }
}