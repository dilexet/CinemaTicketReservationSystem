using System;
using System.Linq;
using CinemaTicketReservationSystem.BLL.Enums;
using CinemaTicketReservationSystem.BLL.Extensions;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Seat
{
    public class SeatRequestValidator : AbstractValidator<SeatRequest>
    {
        public SeatRequestValidator()
        {
            RuleFor(x => x.NumberSeat).NotEqual(0U).NotEmpty().WithMessage("Number seat can't be empty or equals 0");

            RuleFor(x => x.SeatType).NotEmpty().WithMessage("Seat type can't be empty");
            RuleFor(x => x.SeatType).Must(seatType =>
                {
                    try
                    {
                        Enum.GetValues(typeof(SeatTypes))
                            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                            .Cast<SeatTypes>().First(x => x.GetDisplayName().Equals(seatType));
                    }
                    catch (InvalidOperationException)
                    {
                        return false;
                    }

                    return true;
                })
                .WithMessage("Seat type is not exist");
        }
    }
}