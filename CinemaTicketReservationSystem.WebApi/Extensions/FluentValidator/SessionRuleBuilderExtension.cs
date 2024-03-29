﻿using System;
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

        public static IRuleBuilderOptions<T, SessionRequest> StartSessionDateMustBeAfterMovieRelease<T>(
            this IRuleBuilder<T, SessionRequest> ruleBuilder, IRepository<Movie> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (sessionRequest, _) =>
                {
                    var movieExist = await repository.FindByIdAsync(sessionRequest.MovieId);
                    if (movieExist.StartDate > sessionRequest.StartDate)
                    {
                        return false;
                    }

                    return true;
                })
                .WithName("SessionRequest.StartDate")
                .WithMessage("Session start date must be after movie release start date");
            return options;
        }

        public static IRuleBuilderOptions<T, SessionRequest> HallMustBeFree<T>(
            this IRuleBuilder<T, SessionRequest> ruleBuilder, IRepository<Hall> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (sessionRequest, _) =>
                {
                    var hallExist = await repository.FindByIdAsync(sessionRequest.HallId);
                    if (hallExist.Sessions.Any(x =>
                        {
                            var startDate = x.StartDate - TimeSpan.FromHours(2);
                            var endDate = x.StartDate + TimeSpan.FromHours(2);
                            return sessionRequest.StartDate > startDate && sessionRequest.StartDate < endDate;
                        }))
                    {
                        return false;
                    }

                    return true;
                })
                .WithName("SessionRequest.StartDate")
                .WithMessage("Hall will be busy in this time");
            return options;
        }

        public static IRuleBuilderOptions<T, SessionRequest> HallMustExistAsync<T>(
            this IRuleBuilder<T, SessionRequest> ruleBuilder, IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (sessionRequest, _) =>
                {
                    var cinemaExist = await repository.FindByIdAsync(sessionRequest.CinemaId);
                    if (cinemaExist?.Halls.FirstOrDefault(x => x.Id.Equals(sessionRequest.HallId)) == null)
                    {
                        return false;
                    }

                    return true;
                })
                .WithName("HallName")
                .WithMessage("Hall not found in this cinema");
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
                    var cinemaExist = await repository.FindByIdAsync(sessionRequest.CinemaId);
                    if (cinemaExist == null)
                    {
                        return false;
                    }

                    foreach (var sessionAdditionalService in sessionRequest.SessionAdditionalServices)
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
                    var hallExist = await repository.FindByIdAsync(sessionRequest.HallId);
                    if (hallExist == null)
                    {
                        return false;
                    }

                    foreach (var seatType in sessionRequest.SessionSeatTypes)
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