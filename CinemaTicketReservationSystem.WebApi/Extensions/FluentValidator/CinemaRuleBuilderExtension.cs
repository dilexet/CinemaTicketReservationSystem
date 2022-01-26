using System;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class CinemaRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, string> CinemaNameMustExistAsync<T>(
            this IRuleBuilder<T, string> ruleBuilder, IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (cinemaName, _) =>
                    await repository.FirstOrDefaultAsync(x => x.Name.Equals(cinemaName)) != null)
                .WithMessage("Cinema with this name not found");
            return options;
        }

        public static IRuleBuilderOptions<T, string> CinemaNameMustNotExistAsync<T>(
            this IRuleBuilder<T, string> ruleBuilder, IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (cinemaName, _) =>
                    await repository.FirstOrDefaultAsync(x => x.Name.Equals(cinemaName)) == null)
                .WithMessage("Cinema with this name is exists");
            return options;
        }

        public static IRuleBuilderOptions<T, UpdateCinemaRequestWrapper> CinemaNameMustNotExistForUpdateAsync<T>(
            this IRuleBuilder<T, UpdateCinemaRequestWrapper> ruleBuilder, IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (cinema, _) =>
                {
                    var cinemaExist =
                        await repository.FirstOrDefaultAsync(x => x.Name == cinema.CinemaRequest.Name);
                    if (cinemaExist == null)
                    {
                        return true;
                    }

                    return cinemaExist.Id == cinema.Id;
                })
                .WithName("CinemaRequest.Name")
                .WithMessage("Cinema with this name is exists");
            return options;
        }

        public static IRuleBuilderOptions<T, Guid> CinemaMustExistAsync<T>(
            this IRuleBuilder<T, Guid> ruleBuilder, IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (id, _) =>
                    await repository.FindByIdAsync(id) != null)
                .WithMessage("Cinema is not exists");
            return options;
        }
    }
}