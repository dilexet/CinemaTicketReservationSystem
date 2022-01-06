using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserProfile;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.UserProfile
{
    public class UserProfileGetRequestWrapperValidator : AbstractValidator<UserProfileGetRequestWrapper>
    {
        public UserProfileGetRequestWrapperValidator(
            IRepository<DAL.Entity.UserEntity.UserProfile> userProfileRepository)
        {
            RuleFor(x => x.Id).UserProfileMustExistAsync(userProfileRepository);
        }
    }
}