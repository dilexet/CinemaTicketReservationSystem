using System.Linq;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class HallRequestValidator : AbstractValidator<HallRequest>
    {
        public HallRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Hall name can't be empty");
            RuleFor(x => x.NumberOfSeats).NotEqual(0U).NotEmpty()
                .WithMessage("Number of seats can't be empty or equals 0");

            RuleFor(x => x.Rows).NotNull().WithMessage("Rows can't be null");

            RuleFor(x => x).Must(hall => hall.Rows.Sum(row => row.NumberOfSeats) == hall.NumberOfSeats)
                .WithMessage("The number of seats does not match the number of seats on the list");
        }
    }
}