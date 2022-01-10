using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class UpdateCinemaRequestWrapperValidator : AbstractValidator<UpdateCinemaRequestWrapper>
    {
        public UpdateCinemaRequestWrapperValidator(IRepository<DAL.Entity.CinemaEntity.Cinema> cinemaRepository)
        {
            RuleFor(x => x.Id).CinemaMustExistAsync(cinemaRepository);
            RuleFor(x => x).CinemaNameMustNotExistForUpdateAsync(cinemaRepository);
            RuleFor(x => x.CinemaRequest).SetValidator(new CinemaRequestValidator());
        }
    }
}