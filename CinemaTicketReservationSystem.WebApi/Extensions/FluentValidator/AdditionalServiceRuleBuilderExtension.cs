using System;
using System.Linq;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.CinemaEntity;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.AdditionalService;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class AdditionalServiceRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, AddAdditionalServiceRequestWrapper>
            AdditionalServiceNameMustNotExistAsync<T>(
                this IRuleBuilder<T, AddAdditionalServiceRequestWrapper> ruleBuilder, IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (additionalServiceRequestWrapper, _) =>
                {
                    var cinemaExist = await repository.FindByIdAsync(additionalServiceRequestWrapper.CinemaId);
                    return cinemaExist.AdditionalServices.FirstOrDefault(x =>
                        x.Name == additionalServiceRequestWrapper.AdditionalServiceRequest.Name) == null;
                })
                .WithMessage("Additional service with this name is exists in this cinema");
            return options;
        }

        public static IRuleBuilderOptions<T, UpdateAdditionalServiceRequestWrapper>
            AdditionalServiceMustExistInCinemaAsync<T>(
                this IRuleBuilder<T, UpdateAdditionalServiceRequestWrapper> ruleBuilder, IRepository<Cinema> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (additionalServiceRequestWrapper, _) =>
                {
                    var cinemaExist = await repository.FindByIdAsync(additionalServiceRequestWrapper.CinemaId);
                    return cinemaExist.AdditionalServices.FirstOrDefault(x =>
                        x.Id == additionalServiceRequestWrapper.Id) != null;
                })
                .WithMessage("Additional service is not exists");
            return options;
        }

        public static IRuleBuilderOptions<T, Guid>
            AdditionalServiceMustExistAsync<T>(
                this IRuleBuilder<T, Guid> ruleBuilder, IRepository<AdditionalService> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (id, _) =>
                {
                    var additionalServiceExist = await repository.FindByIdAsync(id);
                    return additionalServiceExist != null;
                })
                .WithMessage("Additional service is not exists");
            return options;
        }
    }
}