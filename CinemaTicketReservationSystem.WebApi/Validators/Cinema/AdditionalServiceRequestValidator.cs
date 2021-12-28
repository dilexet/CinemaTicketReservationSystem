using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class AdditionalServiceRequestValidator : AbstractValidator<AdditionalServiceRequest>
    {
        public AdditionalServiceRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Additional service name can't be empty");
        }
    }
}