using System;
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
        private readonly IUserManager<User> _userManager;
        private readonly IRoleManager<Role> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthorizeService(IUserManager<User> userManager, IRoleManager<Role> roleManager,
            ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<AuthorizeResult> LoginAsync(LoginModel loginModel)
        {
            var userExisting = await _userManager.SingleOrDefaultAsync(x =>
                x.Email.Equals(loginModel.Name) || x.Name.Equals(loginModel.Name));

            if (userExisting == null ||
                !_userManager.CheckPassword(userExisting.PasswordHash, loginModel.Password))
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {"Invalid username or password"}
                };
            }

            var tokenResult = await _tokenService.GenerateTokens(_mapper.Map<TokenUserModel>(userExisting));
            if (!tokenResult.Success)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {tokenResult.Error}
                };
            }

            userExisting.RefreshTokens.ToList().Add(tokenResult.RefreshToken);
            if (!await _userManager.UpdateUserAsync(userExisting))
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {"An error occured while updating to the database"}
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
            var userExisting = await _userManager.SingleOrDefaultAsync(x =>
                x.Email.Equals(registerModel.Email) || x.Name.Equals(registerModel.Name));
            if (userExisting != null)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {"User is exists"}
                };
            }

            User user = _mapper.Map<User>(registerModel);
            user.PasswordHash = _userManager.HasPasswordAsync(registerModel.Password);

            var resultCreating = await CreateRolesIfNotExist();
            if (!resultCreating)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {"Unable to add new role"}
                };
            }

            if (await _userManager.SingleOrDefaultAsync() == null)
            {
                user.Role = await _roleManager.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.Admin.ToString()));
            }
            else
            {
                user.Role = await _roleManager.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.User.ToString()));
            }

            if (!await _userManager.CreateUserAsync(user))
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {"An error occured while adding to the database"}
                };
            }

            var tokenResult = await _tokenService.GenerateTokens(_mapper.Map<TokenUserModel>(user));
            if (!tokenResult.Success)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {tokenResult.Error}
                };
            }

            user.RefreshTokens.ToList().Add(tokenResult.RefreshToken);

            if (!await _userManager.UpdateUserAsync(user))
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {"An error occured while updating to the database"}
                };
            }

            return new AuthorizeResult()
            {
                Success = true,
                JwtToken = tokenResult.JwtToken,
                RefreshToken = tokenResult.RefreshToken.Token
            };
        }

        public async Task<AuthorizeResult> RefreshTokenAsync(String username, String refreshToken)
        {
            var userExisting = await _userManager.SingleOrDefaultAsync(x =>
                x.Email.Equals(username) || x.Name.Equals(username));
            if (userExisting == null)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {"User is not exists"}
                };
            }

            var token = userExisting.RefreshTokens.FirstOrDefault(x => x.Token.Equals(refreshToken));
            if (token == null)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {"Token is not exists"}
                };
            }

            var refreshTokenResult =
                await _tokenService.RefreshJwtToken(_mapper.Map<TokenUserModel>(userExisting), token);

            if (!refreshTokenResult.Success)
            {
                return new AuthorizeResult()
                {
                    Success = false,
                    Errors = new[] {refreshTokenResult.Error}
                };
            }

            return new AuthorizeResult()
            {
                Success = true,
                JwtToken = refreshTokenResult.JwtToken,
                RefreshToken = refreshTokenResult.RefreshToken.Token
            };
        }

        private async Task<bool> CreateRolesIfNotExist()
        {
            try
            {
                if (await _roleManager.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.Admin.ToString())) == null)
                {
                    await _roleManager.CreateRoleAsync(new Role() {Name = RoleTypes.Admin.ToString()});
                }

                if (await _roleManager.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.Manager.ToString())) == null)
                {
                    await _roleManager.CreateRoleAsync(new Role() {Name = RoleTypes.Manager.ToString()});
                }

                if (await _roleManager.SingleOrDefaultAsync(x => x.Name.Equals(RoleTypes.User.ToString())) == null)
                {
                    await _roleManager.CreateRoleAsync(new Role() {Name = RoleTypes.User.ToString()});
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}