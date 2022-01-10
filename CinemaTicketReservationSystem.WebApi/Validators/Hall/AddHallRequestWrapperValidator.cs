using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Hall;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Hall
{
    public class AddHallRequestWrapperValidator : AbstractValidator<AddHallRequestWrapper>
    {
        public AddHallRequestWrapperValidator(IRepository<DAL.Entity.CinemaEntity.Cinema> cinemaRepository)
        {
            RuleFor(x => x.CinemaId).CinemaMustExistAsync(cinemaRepository);
            RuleFor(x => x).HallMustNotExistInCinemaAsync(cinemaRepository);
            RuleFor(x => x.HallRequest).SetValidator(new HallRequestValidator());
        }
    }
}