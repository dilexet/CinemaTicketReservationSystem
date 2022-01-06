using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserManagement;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.User
{
    public class UserRequestWrapperValidator : AbstractValidator<UserRequestWrapper>
    {
        public UserRequestWrapperValidator(
            IUserRepository userRepository)
        {
            RuleFor(x => x.Id).UserMustExistAsync(userRepository);
        }
    }
}