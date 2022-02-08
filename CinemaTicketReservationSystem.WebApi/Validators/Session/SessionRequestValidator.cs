using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Session;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Session
{
    public class SessionRequestValidator : AbstractValidator<SessionRequest>
    {
        public SessionRequestValidator(
            IRepository<DAL.Entity.MovieEntity.Movie> movieRepository,
            IRepository<DAL.Entity.CinemaEntity.Cinema> cinemaRepository,
            IRepository<DAL.Entity.CinemaEntity.Hall> hallRepository)
        {
            RuleFor(x => x.MovieId).MovieMustExistAsync(movieRepository);
            RuleFor(x => x.CinemaId).CinemaNameMustExistAsync(cinemaRepository);

            RuleFor(x => x)
                .HallMustExistAsync(cinemaRepository);

            RuleFor(x => x)
                .AdditionalServicesMustExistAsync(cinemaRepository);

            RuleFor(x => x)
                .SeatTypesMustExistAsync(hallRepository);

            RuleFor(x => x.StartDate).NotNull().NotEmpty().WithMessage("Session start date can't be empty");
            RuleFor(x => x).StartSessionDateMustBeAfterMovieRelease(movieRepository);
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie name can't be empty");

            RuleFor(x => x.CinemaId).NotEmpty().WithMessage("Cinema name can't be empty");
            RuleFor(x => x.HallId).NotEmpty().WithMessage("Hall name can't be empty");

            RuleFor(x => x.SessionAdditionalServices)
                .ForEach(x => x.SetValidator(new SessionAdditionalServicesRequestValidator()));

            RuleFor(x => x.SessionSeatTypes)
                .ForEach(x => x.SetValidator(new SessionSeatTypeRequestValidator()));
        }
    }
}