using System;
using System.Linq;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.DAL.Entity.SessionEntity;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Session;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class SessionRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, Guid> SessionMustExistAsync<T>(
            this IRuleBuilder<T, Guid> ruleBuilder, IRepository<Session> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (id, _) =>
                {
                    var sessionExist = await repository.FindByIdAsync(id);
                    return sessionExist != null;
                })
                .WithName("Session")
                .WithMessage("Session is not exists");
            return options;
        }

        public static IRuleBuilderOptions<T, string> MovieMustExistAsync<T>(
            this IRuleBuilder<T, string> ruleBuilder, IRepository<Movie> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (movieName, _) =>
                {
                    return await repository.FirstOrDefaultAsync(x => x.Name.Equals(movieName)) != null;
                })
                .WithName("MovieName")
                .WithMessage("Movie with this name not found");
            return options;
        }

        public static IRuleBuilderOptions<T, SessionRequest> HallMustExistAsync<T>(
            this IRuleBuilder<T, SessionRequest> ruleBuilder, IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (sessionRequest, _) =>
                {
                    var cinemaExist = await repository.FirstOrDefaultAsync(x =>
                        x.Name.Equals(sessionRequest.CinemaName));
                    if (cinemaExist?.Halls.FirstOrDefault(x => x.Name.Equals(sessionRequest.HallName)) == null)
                    {
                        return false;
                    }

                    return true;
                })
                .WithName("HallName")
                .WithMessage("Hall with this name not found in this cinema");
            return options;
        }

        public static IRuleBuilderOptions<T, SessionRequest>
            AdditionalServicesMustExistAsync<T>(
                this IRuleBuilder<T, SessionRequest> ruleBuilder,
                IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (sessionRequest, _) =>
                {
                    var cinemaExist = await repository.FirstOrDefaultAsync(x =>
                        x.Name.Equals(sessionRequest.CinemaName));
                    if (cinemaExist == null)
                    {
                        return false;
                    }

                    foreach (var sessionAdditionalService in sessionRequest.SessionAdditionalServicesRequest)
                    {
                        var additionalServiceExist = cinemaExist.AdditionalServices.FirstOrDefault(service =>
                            service.Name.Equals(sessionAdditionalService.Name));
                        if (additionalServiceExist == null)
                        {
                            return false;
                        }
                    }

                    return true;
                })
                .WithName("AdditionalServiceName")
                .WithMessage("Additional service with this name not found in this cinema");
            return options;
        }

        public static IRuleBuilderOptions<T, SessionRequest> SeatTypesMustExistAsync<T>(
            this IRuleBuilder<T, SessionRequest> ruleBuilder,
            IRepository<Hall> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (sessionRequest, _) =>
                {
                    var hallExist = await repository.FirstOrDefaultAsync(x =>
                        x.Name.Equals(sessionRequest.HallName));
                    if (hallExist == null)
                    {
                        return false;
                    }

                    foreach (var seatType in sessionRequest.SessionSeatTypesRequest)
                    {
                        var seatTypeExist = hallExist.SeatTypes.FirstOrDefault(x => x.Equals(seatType.SeatType));
                        if (seatTypeExist == null)
                        {
                            return false;
                        }
                    }

                    return true;
                })
                .WithName("SeatTypeName")
                .WithMessage("Seat type with this name not found in this hall");
            return options;
        }
    }
}