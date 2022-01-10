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
            RuleFor(x => x.MovieName).MovieMustExistAsync(movieRepository);
            RuleFor(x => x.CinemaName).CinemaNameMustExistAsync(cinemaRepository);

            RuleFor(x => x)
                .HallMustExistAsync(cinemaRepository);

            RuleFor(x => x)
                .AdditionalServicesMustExistAsync(cinemaRepository);

            RuleFor(x => x)
                .SeatTypesMustExistAsync(hallRepository);

            RuleFor(x => x.StartDate).NotNull().NotEmpty().WithMessage("Session start date can't be empty");
            RuleFor(x => x.MovieName).NotEmpty().WithMessage("Movie name can't be empty");

            RuleFor(x => x.CinemaName).NotEmpty().WithMessage("Cinema name can't be empty");
            RuleFor(x => x.HallName).NotEmpty().WithMessage("Hall name can't be empty");

            RuleFor(x => x.SessionAdditionalServicesRequest)
                .ForEach(x => x.SetValidator(new SessionAdditionalServicesRequestValidator()));

            RuleFor(x => x.SessionSeatTypesRequest)
                .ForEach(x => x.SetValidator(new SessionSeatTypeRequestValidator()));
        }
    }
}