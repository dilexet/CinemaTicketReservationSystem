using System.Linq;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Booking;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class BookingRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, BookTicketsRequestWrapper> SessionSeatsMustExistAsync<T>(
            this IRuleBuilder<T, BookTicketsRequestWrapper> ruleBuilder, IRepository<Session> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (bookingRequest, _) =>
                {
                    var sessionExist = await repository.FindByIdAsync(bookingRequest.Id);
                    if (sessionExist == null)
                    {
                        return false;
                    }

                    return bookingRequest.BookTicketsRequest.SessionSeatsId
                        .All(seatId => sessionExist.SessionSeats
                            .FirstOrDefault(x => x.Id == seatId) != null);
                })
                .WithName("SessionSeat")
                .WithMessage("Session seat is not exists or booked");
            return options;
        }

        public static IRuleBuilderOptions<T, BookTicketsRequestWrapper> SessionAdditionalServicesMustExistAsync<T>(
            this IRuleBuilder<T, BookTicketsRequestWrapper> ruleBuilder, IRepository<Session> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (bookingRequest, _) =>
                {
                    var sessionExist = await repository.FindByIdAsync(bookingRequest.Id);
                    if (sessionExist == null)
                    {
                        return false;
                    }

                    return bookingRequest.BookTicketsRequest.SessionAdditionalServicesId
                        .All(additionalServiceId => sessionExist.SessionAdditionalServices
                            .FirstOrDefault(x => x.Id == additionalServiceId) != null);
                })
                .WithName("SessionAdditionalService")
                .WithMessage("Additional service is not exists");
            return options;
        }
    }
}