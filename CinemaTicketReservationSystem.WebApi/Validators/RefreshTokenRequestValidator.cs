using CinemaTicketReservationSystem.WebApi.Models.Requests.Token;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators
{
    public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>

    {
        public RefreshTokenRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username can't be empty");
            RuleFor(x => x.Token).NotEmpty().WithMessage("Token can't be empty");
        }
    }
}