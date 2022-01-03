using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class SeatRequestValidator : AbstractValidator<SeatRequest>
    {
        public SeatRequestValidator()
        {
            RuleFor(x => x.NumberSeat).NotEqual(0U).NotEmpty().WithMessage("Number seat can't be empty or equals 0");

            RuleFor(x => x.SeatType).NotEmpty().WithMessage("Seat type can't be empty");
        }
    }
}