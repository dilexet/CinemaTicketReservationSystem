using System.Linq;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using CinemaTicketReservationSystem.WebApi.Validators.Row;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Hall
{
    public class HallRequestValidator : AbstractValidator<HallRequest>
    {
        public HallRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Hall name can't be empty");
            RuleFor(x => x.NumberOfRows).NotEqual(0U).NotEmpty()
                .WithMessage("Number of seats can't be empty or equals 0");

            RuleFor(x => x.Rows).NotNull().WithMessage("Rows can't be null");

            RuleFor(x => x).Must(hall => hall.Rows.Count() == hall.NumberOfRows)
                .WithMessage("The number of rows does not match the number of rows on the list");

            RuleFor(x => x.Rows)
                .ForEach(x => x.SetValidator(new RowRequestValidator()));

            RuleFor(x => x.Rows).Must(x =>
            {
                var rows = x.ToList();
                return rows.Select(row => row.NumberRow).Distinct().Count() == rows.Count;
            }).WithMessage("Rows number must be unique");
        }
    }
}