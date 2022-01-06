using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.AdditionalService
{
    public class AdditionalServiceRequestValidator : AbstractValidator<AdditionalServiceRequest>
    {
        public AdditionalServiceRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Please enter the additional service name");
        }
    }
}