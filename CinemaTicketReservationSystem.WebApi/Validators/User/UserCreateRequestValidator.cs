using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.User
{
    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter the username");
            RuleFor(x => x.Name).Length(5, 16).WithMessage("Username must be between 5 and 16 characters");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Please enter the email");
            RuleFor(x => x.Email).EmailAddress().WithMessage("The Email field is not a valid e-mail address");

            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please enter the role");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter the password");
            RuleFor(x => x.Password).Length(4, 25).WithMessage("Password must be between 4 and 25 characters");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Please enter the confirmation password");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password)
                .WithMessage("The password and confirmation password do not match");
        }
    }
}