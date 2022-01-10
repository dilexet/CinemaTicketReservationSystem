using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserManagement;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.User
{
    public class CreateUserRequestWrapperValidator : AbstractValidator<CreateUserRequestWrapper>
    {
        public CreateUserRequestWrapperValidator(IUserRepository userRepository, IRepository<Role> roleRepository)
        {
            RuleFor(x => x.UserCreateRequest)
                .SetValidator(new UserCreateRequestValidator());

            RuleFor(x => x.UserCreateRequest).UserMustNotExistAsync(userRepository);
            RuleFor(x => x.UserCreateRequest.RoleName).RoleMustExistAsync(roleRepository);
        }
    }
}