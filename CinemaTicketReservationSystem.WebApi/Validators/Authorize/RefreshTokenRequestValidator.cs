using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Token;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Authorize
{
    public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User id can't be empty");
            RuleFor(x => x.Token).NotEmpty().WithMessage("Token can't be empty");
            RuleFor(x => x).RefreshTokenMustExistAsync(userRepository);
        }
    }
}