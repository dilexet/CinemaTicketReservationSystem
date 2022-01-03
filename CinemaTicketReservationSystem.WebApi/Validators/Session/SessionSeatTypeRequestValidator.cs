using CinemaTicketReservationSystem.WebApi.Models.Requests.Session;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Session
{
    public class SessionSeatTypeRequestValidator : AbstractValidator<SessionSeatTypeRequest>
    {
        public SessionSeatTypeRequestValidator()
        {
            RuleFor(x => x.SeatType).NotEmpty().WithMessage("Session seat type can't be empty");

            RuleFor(x => x.Price).NotEmpty().NotEqual(0)
                .WithMessage("Session seat type price can't be empty or equal 0");
        }
    }
}