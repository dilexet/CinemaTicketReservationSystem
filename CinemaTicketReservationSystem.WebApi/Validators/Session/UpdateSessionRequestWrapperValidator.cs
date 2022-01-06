using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Session;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Session
{
    public class UpdateSessionRequestWrapperValidator : AbstractValidator<UpdateSessionRequestWrapper>
    {
        public UpdateSessionRequestWrapperValidator(
            IRepository<DAL.Entity.SessionEntity.Session> sessionRepository,
            IRepository<DAL.Entity.MovieEntity.Movie> movieRepository,
            IRepository<DAL.Entity.CinemaEntity.Cinema> cinemaRepository,
            IRepository<DAL.Entity.CinemaEntity.Hall> hallRepository)
        {
            RuleFor(x => x.Id).SessionMustExistAsync(sessionRepository);
            RuleFor(x => x.SessionRequest)
                .SetValidator(new SessionRequestValidator(movieRepository, cinemaRepository, hallRepository));
        }
    }
}