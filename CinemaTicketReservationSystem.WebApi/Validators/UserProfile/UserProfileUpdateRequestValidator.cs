using CinemaTicketReservationSystem.WebApi.Models.Requests.User;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.UserProfile
{
    public class UserProfileUpdateRequestValidator : AbstractValidator<UserProfileUpdateRequest>
    {
        public UserProfileUpdateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter the name");
            RuleFor(x => x.Name).Length(2, 25).WithMessage("Name must be between 2 and 25 characters");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Please enter the surname");
            RuleFor(x => x.Surname).Length(2, 25).WithMessage("Surname must be between 2 and 25 characters");
        }
    }
}