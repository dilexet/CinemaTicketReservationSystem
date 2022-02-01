using System;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.MovieEntity;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Movie;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class MovieRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, Guid> MovieMustExistAsync<T>(
            this IRuleBuilder<T, Guid> ruleBuilder, IRepository<Movie> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (id, _) =>
                {
                    var movieExist = await repository.FindByIdAsync(id);
                    return movieExist != null;
                })
                .WithName("Movie")
                .WithMessage("Movie is not exists");
            return options;
        }

        public static IRuleBuilderOptions<T, UpdateMovieRequestWrapper> MovieMustNotExistForUpdateAsync<T>(
            this IRuleBuilder<T, UpdateMovieRequestWrapper> ruleBuilder, IRepository<Movie> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (movieRequestWrapper, _) =>
                {
                    var movieExist =
                        await repository.FirstOrDefaultAsync(x => x.Name == movieRequestWrapper.MovieRequest.Name);
                    if (movieExist == null)
                    {
                        return true;
                    }

                    return movieExist.Id == movieRequestWrapper.Id;
                })
                .WithName("MovieRequest.Name")
                .WithMessage("Movie with this name is exists");
            return options;
        }

        public static IRuleBuilderOptions<T, string> MovieMustNotExistAsync<T>(
            this IRuleBuilder<T, string> ruleBuilder, IRepository<Movie> repository)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MustAsync(async (movieName, _) =>
                {
                    var movieExist =
                        await repository.FirstOrDefaultAsync(x => x.Name == movieName);
                    return movieExist == null;
                })
                .WithName("MovieName")
                .WithMessage("Movie with this name is exists");
            return options;
        }
    }
}