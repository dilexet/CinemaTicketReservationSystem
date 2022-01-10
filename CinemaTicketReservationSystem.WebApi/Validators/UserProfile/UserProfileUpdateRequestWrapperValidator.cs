using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserProfile;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.UserProfile
{
    public class UserProfileUpdateRequestWrapperValidator : AbstractValidator<UserProfileUpdateRequestWrapper>
    {
        public UserProfileUpdateRequestWrapperValidator(
            IRepository<DAL.Entity.UserEntity.UserProfile> userProfileRepository)
        {
            RuleFor(x => x.UserProfileUpdateRequest).SetValidator(new UserProfileUpdateRequestValidator());
            RuleFor(x => x.Id).UserProfileMustExistAsync(userProfileRepository);
        }
    }
}