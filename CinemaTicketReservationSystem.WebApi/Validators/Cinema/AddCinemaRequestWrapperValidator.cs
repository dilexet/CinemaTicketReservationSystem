using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class AddCinemaRequestWrapperValidator : AbstractValidator<AddCinemaRequestWrapper>
    {
        public AddCinemaRequestWrapperValidator(IRepository<DAL.Entity.CinemaEntity.Cinema> cinemaRepository)
        {
            RuleFor(x => x.CinemaRequest.Name).CinemaNameMustNotExistAsync(cinemaRepository);
            RuleFor(x => x.CinemaRequest).SetValidator(new CinemaRequestValidator());
        }
    }
}