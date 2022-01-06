using System.Linq;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Token;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class AuthorizeRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, UserLoginRequest> LoginMustBeValidAsync<T>(
            this IRuleBuilder<T, UserLoginRequest> ruleBuilder,
            IUserRepository userRepository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (login, _) =>
                {
                    var userExisting = await userRepository.FirstOrDefaultAsync(x =>
                        x.Email.Equals(login.Name) || x.Name.Equals(login.Name));
                    if (userExisting == null)
                    {
                        return false;
                    }

                    var isPasswordValid = userRepository.CheckPassword(userExisting.PasswordHash, login.Password);
                    if (!isPasswordValid)
                    {
                        return false;
                    }

                    return true;
                })
                .WithName("User")
                .WithMessage("Invalid username or password");
            return options;
        }

        public static IRuleBuilderOptions<T, UserRegisterRequest> UserMustNotExistAsync<T>(
            this IRuleBuilder<T, UserRegisterRequest> ruleBuilder,
            IUserRepository userRepository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (user, _) =>
                {
                    var userExisting = await userRepository.FirstOrDefaultAsync(x =>
                        x.Email.Equals(user.Email) || x.Name.Equals(user.Name));
                    return userExisting == null;
                })
                .WithName("User")
                .WithMessage("User is exists");
            return options;
        }

        public static IRuleBuilderOptions<T, RefreshTokenRequest> RefreshTokenMustExistAsync<T>(
            this IRuleBuilder<T, RefreshTokenRequest> ruleBuilder,
            IUserRepository userRepository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (tokenRequest, _) =>
                {
                    var userExisting = await userRepository.FindByIdAsync(tokenRequest.UserId);
                    if (userExisting == null)
                    {
                        return false;
                    }

                    var token = userExisting.RefreshTokens.FirstOrDefault(x => x.Token.Equals(tokenRequest.Token));
                    if (token == null)
                    {
                        return false;
                    }

                    return true;
                })
                .WithName("TokenId")
                .WithMessage("Token is not exists");
            return options;
        }
    }
}