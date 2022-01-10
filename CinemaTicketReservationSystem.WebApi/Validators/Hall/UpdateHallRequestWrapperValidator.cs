using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Hall;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Hall
{
    public class UpdateHallRequestWrapperValidator : AbstractValidator<UpdateHallRequestWrapper>
    {
        public UpdateHallRequestWrapperValidator(IRepository<DAL.Entity.CinemaEntity.Hall> hallRepository)
        {
            RuleFor(x => x.Id).HallMustExistAsync(hallRepository);
            RuleFor(x => x).HallMustNotExistForUpdateInCinemaAsync(hallRepository);
            RuleFor(x => x.HallRequest).SetValidator(new HallRequestValidator());
        }
    }
}