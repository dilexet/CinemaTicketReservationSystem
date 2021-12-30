using CinemaTicketReservationSystem.WebApi.Models.Requests.Session;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Session
{
    public class SessionAdditionalServicesRequestValidator : AbstractValidator<SessionAdditionalServiceRequest>
    {
        public SessionAdditionalServicesRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Session additional service name can't be empty");

            RuleFor(x => x.Price).NotEmpty().NotEqual(0)
                .WithMessage("Session additional service price can't be empty or equal 0");
        }
    }
}