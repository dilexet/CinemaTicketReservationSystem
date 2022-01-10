using System;
using CinemaTicketReservationSystem.DAL.Abstract;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class UserProfileRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, Guid> UserProfileMustExistAsync<T>(
            this IRuleBuilder<T, Guid> ruleBuilder, IRepository<DAL.Entity.UserEntity.UserProfile> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (id, _) =>
                    await repository.FindByIdAsync(id) != null)
                .WithName("UserProfileId")
                .WithMessage("User profile is not exists");
            return options;
        }
    }
}