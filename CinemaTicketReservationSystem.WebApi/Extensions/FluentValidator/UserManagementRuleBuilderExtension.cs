using System;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.UserManagement;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class UserManagementRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, Guid> RoleMustExistAsync<T>(
            this IRuleBuilder<T, Guid> ruleBuilder, IRepository<Role> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (roleId, _) =>
                    await repository.FindByIdAsync(roleId) != null)
                .WithName("Role")
                .WithMessage("Role is not exists");
            return options;
        }

        public static IRuleBuilderOptions<T, UpdateUserRequestWrapper> UserMustNotExistForUpdateAsync<T>(
            this IRuleBuilder<T, UpdateUserRequestWrapper> ruleBuilder,
            IUserRepository userRepository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (user, _) =>
                {
                    var userExisting = await userRepository.FirstOrDefaultAsync(x =>
                        x.Email.Equals(user.UserUpdateRequest.Email) || x.Name.Equals(user.UserUpdateRequest.Name));
                    if (userExisting == null)
                    {
                        return true;
                    }

                    return userExisting.Id == user.Id;
                })
                .WithName("User")
                .WithMessage("User is exists");
            return options;
        }

        public static IRuleBuilderOptions<T, CreateUserRequestWrapper> UserMustNotExistAsync<T>(
            this IRuleBuilder<T, CreateUserRequestWrapper> ruleBuilder,
            IUserRepository userRepository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (user, _) =>
                {
                    var userExisting = await userRepository.FirstOrDefaultAsync(x =>
                        x.Email.Equals(user.UserCreateRequest.Email) || x.Name.Equals(user.UserCreateRequest.Name));
                    return userExisting == null;
                })
                .WithName("User")
                .WithMessage("User is exists");
            return options;
        }

        public static IRuleBuilderOptions<T, Guid> UserMustExistAsync<T>(
            this IRuleBuilder<T, Guid> ruleBuilder, IUserRepository repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (id, _) =>
                    await repository.FindByIdAsync(id) != null)
                .WithName("User")
                .WithMessage("User is not exists");
            return options;
        }
    }
}