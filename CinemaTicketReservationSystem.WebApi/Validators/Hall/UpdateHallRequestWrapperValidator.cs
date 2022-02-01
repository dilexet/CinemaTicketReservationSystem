using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Hall;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Hall
{
    public class UpdateHallRequestWrapperValidator : AbstractValidator<UpdateHallRequestWrapper>
    {
        public UpdateHallRequestWrapperValidator(
            IRepository<DAL.Entity.CinemaEntity.Hall> hallRepository,
            IRepository<DAL.Entity.CinemaEntity.Cinema> cinemaRepository)
        {
            RuleFor(x => x.Id).HallMustExistAsync(hallRepository);
            RuleFor(x => x.CinemaId).CinemaMustExistAsync(cinemaRepository);
            RuleFor(x => x).HallMustNotExistForUpdateInCinemaAsync(cinemaRepository);
            RuleFor(x => x.HallRequest).SetValidator(new HallRequestValidator());
        }
    }
}