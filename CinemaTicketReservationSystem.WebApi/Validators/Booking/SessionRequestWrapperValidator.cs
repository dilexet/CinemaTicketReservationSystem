using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Session;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Booking
{
    public class SessionRequestWrapperValidator : AbstractValidator<SessionRequestWrapper>
    {
        public SessionRequestWrapperValidator(IRepository<DAL.Entity.SessionEntity.Session> sessionRepository)
        {
            RuleFor(x => x.Id).SessionMustExistAsync(sessionRepository);
        }
    }
}