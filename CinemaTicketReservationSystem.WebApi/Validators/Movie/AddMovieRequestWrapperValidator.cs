using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Movie;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Movie
{
    public class AddMovieRequestWrapperValidator : AbstractValidator<AddMovieRequestWrapper>
    {
        public AddMovieRequestWrapperValidator(IRepository<DAL.Entity.MovieEntity.Movie> movieRepository)
        {
            RuleFor(x => x.MovieRequest.Name).MovieMustNotExistAsync(movieRepository);
            RuleFor(x => x.MovieRequest).SetValidator(new MovieRequestValidator());
        }
    }
}