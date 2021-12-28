using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.User
{
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter the username");
            RuleFor(x => x.Name).Length(5, 16).WithMessage("Username must be between 5 and 16 characters");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Please enter the email");
            RuleFor(x => x.Email).Length(5, 20).WithMessage("Email must be between 5 and 20 characters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("The Email field is not a valid e-mail address");

            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Please enter the role name");
        }
    }
}