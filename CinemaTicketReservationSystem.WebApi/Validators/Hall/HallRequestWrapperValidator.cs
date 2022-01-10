using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Hall;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Hall
{
    public class HallRequestWrapperValidator : AbstractValidator<HallRequestWrapper>
    {
        public HallRequestWrapperValidator(IRepository<DAL.Entity.CinemaEntity.Hall> hallRepository)
        {
            RuleFor(x => x.Id).HallMustExistAsync(hallRepository);
        }
    }
}