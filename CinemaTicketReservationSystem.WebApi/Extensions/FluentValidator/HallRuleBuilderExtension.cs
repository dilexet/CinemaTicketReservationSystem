using System;
using System.Linq;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Hall;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class HallRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, AddHallRequestWrapper> HallMustNotExistInCinemaAsync<T>(
            this IRuleBuilder<T, AddHallRequestWrapper> ruleBuilder, IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (hallRequest, _) =>
                {
                    var cinemaExist = await repository.FindByIdAsync(hallRequest.CinemaId);
                    return cinemaExist?.Halls.FirstOrDefault(x => x.Name.Equals(hallRequest.HallRequest.Name)) == null;
                })
                .WithName("HallName")
                .WithMessage("Hall with this name is exists");
            return options;
        }

        public static IRuleBuilderOptions<T, UpdateHallRequestWrapper> HallMustNotExistForUpdateInCinemaAsync<T>(
            this IRuleBuilder<T, UpdateHallRequestWrapper> ruleBuilder, IRepository<Hall> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (hallRequest, _) =>
                {
                    var hallExist = await repository.FirstOrDefaultAsync(x => x.Name == hallRequest.HallRequest.Name);
                    if (hallExist == null)
                    {
                        return true;
                    }

                    return hallExist.Id == hallRequest.Id;
                })
                .WithName("HallName")
                .WithMessage("Hall with this name is exists");
            return options;
        }

        public static IRuleBuilderOptions<T, Guid> HallMustExistAsync<T>(
            this IRuleBuilder<T, Guid> ruleBuilder, IRepository<Hall> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (id, _) =>
                {
                    var hallExist = await repository.FindByIdAsync(id);
                    return hallExist != null;
                })
                .WithName("Hall")
                .WithMessage("Hall is not exists");
            return options;
        }
    }
}