using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class CinemaRequestValidator : AbstractValidator<CinemaRequest>
    {
        public CinemaRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Cinema name can't be empty");

            RuleFor(x => x.CityName).NotEmpty().WithMessage("City name can't be empty");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street can't be empty");
        }
    }
}