using System.Linq;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class RowRequestValidator : AbstractValidator<RowRequest>
    {
        public RowRequestValidator()
        {
            RuleFor(x => x.NumberRow).NotEqual(0U).NotEmpty().WithMessage("Number row can't be empty or equals 0");
            RuleFor(x => x.NumberRow).NotEqual(0U).NotEmpty().WithMessage("Number of seats can't be empty or equals 0");
            RuleFor(x => x.Seats).NotNull().WithMessage("Seats can't be null");
            RuleFor(x => x).Must(row => row.Seats.Count() == row.NumberOfSeats)
                .WithMessage("The number of seats does not match the number of seats on the list");
        }
    }
}