using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserManagement;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.User
{
    public class UpdateUserRequestWrapperValidator : AbstractValidator<UpdateUserRequestWrapper>
    {
        public UpdateUserRequestWrapperValidator(IUserRepository userRepository, IRepository<Role> roleRepository)
        {
            RuleFor(x => x.UserUpdateRequest)
                .SetValidator(new UserUpdateRequestValidator());

            RuleFor(x => x.Id).UserMustExistAsync(userRepository);

            RuleFor(x => x).UserMustNotExistForUpdateAsync(userRepository);
            RuleFor(x => x.UserUpdateRequest.RoleName).RoleMustExistAsync(roleRepository);
        }
    }
}