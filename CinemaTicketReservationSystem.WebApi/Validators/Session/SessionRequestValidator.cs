using CinemaTicketReservationSystem.WebApi.Models.Requests.Session;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Session
{
    public class SessionRequestValidator : AbstractValidator<SessionRequest>
    {
        public SessionRequestValidator()
        {
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