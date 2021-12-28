using System.Linq;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class CinemaRequestValidator : AbstractValidator<CinemaRequest>
    {
        public CinemaRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Hall name can't be empty");
            RuleFor(x => x.NumberOfHalls).NotEqual(0U).NotEmpty()
                .WithMessage("Number of halls can't be empty or equals 0");

            RuleFor(x => x.CityName).NotEmpty().WithMessage("City name can't be empty");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street can't be empty");

            RuleFor(x => x.AdditionalServices).NotNull().WithMessage("Additional services can't be null");

            RuleFor(x => x.Halls).NotNull().WithMessage("Additional services can't be null");

            RuleFor(x => x).Must(cinema => cinema.Halls.Count() == cinema.NumberOfHalls)
                .WithMessage("The number of halls does not match the number of halls on the list");
        }
    }
}