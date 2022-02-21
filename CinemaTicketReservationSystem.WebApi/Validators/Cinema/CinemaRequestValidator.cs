using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class CinemaRequestValidator : AbstractValidator<CinemaRequest>
    {
        public CinemaRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Cinema name can't be empty");

            RuleFor(x => x.City).NotEmpty().WithMessage("City can't be empty");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country can't be empty");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street can't be empty");
            RuleFor(x => x.Latitude).NotEmpty().WithMessage("Latitude can't be empty");
            RuleFor(x => x.Longitude).NotEmpty().WithMessage("Longitude can't be empty");
        }
    }
}