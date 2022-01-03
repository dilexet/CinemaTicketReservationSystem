using System.Linq;
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

            RuleFor(x => x.AdditionalServices).NotNull().WithMessage("Additional services can't be null");

            RuleFor(x => x.Halls).NotNull().WithMessage("Additional services can't be null");
            RuleFor(x => x.Halls).Must(x =>
            {
                var halls = x.ToList();
                return halls.Select(hall => hall.Name).Distinct().Count() == halls.Count();
            }).WithMessage("Halls name must be unique");

            RuleFor(x => x.Halls)
                .ForEach(x => x.SetValidator(new HallRequestValidator()));

            RuleFor(x => x.AdditionalServices)
                .ForEach(x => x.SetValidator(new AdditionalServiceRequestValidator()));
        }
    }
}