using CinemaTicketReservationSystem.WebApi.Models.Requests.Movie;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators
{
    public class MovieRequestValidator : AbstractValidator<MovieRequest>
    {
        // TODO: add parameters
        public MovieRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Movie name can't be empty");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description can't be empty");
            RuleFor(x => x.Countries).NotNull().NotEmpty().WithMessage("Countries can't be empty");
            RuleFor(x => x.Genres).NotNull().NotEmpty().WithMessage("Genres can't be empty");
        }
    }
}