using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Movie;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Movie
{
    public class UpdateMovieRequestWrapperValidator : AbstractValidator<UpdateMovieRequestWrapper>
    {
        public UpdateMovieRequestWrapperValidator(IRepository<DAL.Entity.MovieEntity.Movie> movieRepository)
        {
            RuleFor(x => x.Id).MovieMustExistAsync(movieRepository);
            RuleFor(x => x).MovieMustNotExistForUpdateAsync(movieRepository);
            RuleFor(x => x.MovieRequest).SetValidator(new MovieRequestValidator());
        }
    }
}