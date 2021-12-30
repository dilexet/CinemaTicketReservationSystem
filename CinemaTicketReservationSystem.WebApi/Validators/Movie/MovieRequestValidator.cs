using System;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Movie;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Movie
{
    public class MovieRequestValidator : AbstractValidator<MovieRequest>
    {
        public MovieRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Movie name can't be empty");

            RuleFor(x => x.PosterUrl).NotEmpty().WithMessage("Poster url can't be empty");
            RuleFor(x => x.PosterUrl)
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
                             (uriResult.Scheme == Uri.UriSchemeHttp ||
                              uriResult.Scheme == Uri.UriSchemeHttps))
                .WithMessage("Poster url doesn't match URL format");

            RuleFor(x => x.StartDate).NotNull().NotEmpty().WithMessage("Movie start date can't be empty");
            RuleFor(x => x.EndDate).NotNull().NotEmpty().WithMessage("Movie end date can't be empty");
            RuleFor(x => x.ReleaseDate).NotNull().NotEmpty().WithMessage("Movie release date can't be empty");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description can't be empty");
            RuleFor(x => x.Countries).NotNull().NotEmpty().WithMessage("Countries can't be empty");
            RuleFor(x => x.Genres).NotNull().NotEmpty().WithMessage("Genres can't be empty");
        }
    }
}