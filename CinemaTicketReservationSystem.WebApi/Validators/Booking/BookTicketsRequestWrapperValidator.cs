using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Booking;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Booking
{
    public class BookTicketsRequestWrapperValidator : AbstractValidator<BookTicketsRequestWrapper>
    {
        public BookTicketsRequestWrapperValidator(
            IRepository<DAL.Entity.SessionEntity.Session> sessionRepository,
            IRepository<DAL.Entity.UserEntity.UserProfile> userProfileRepository)
        {
            RuleFor(x => x.Id).SessionMustExistAsync(sessionRepository);
            RuleFor(x => x.BookTicketsRequest.UserProfileId)
                .UserProfileMustExistAsync(userProfileRepository);
            RuleFor(x => x).SessionSeatsMustExistAsync(sessionRepository);
            RuleFor(x => x).SessionAdditionalServicesMustExistAsync(sessionRepository);
        }
    }
}