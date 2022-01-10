using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Movie;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Movie
{
    public class MovieRequestWrapperValidator : AbstractValidator<MovieRequestWrapper>
    {
        public MovieRequestWrapperValidator(IRepository<DAL.Entity.MovieEntity.Movie> movieRepository)
        {
            RuleFor(x => x.Id).MovieMustExistAsync(movieRepository);
        }
    }
}