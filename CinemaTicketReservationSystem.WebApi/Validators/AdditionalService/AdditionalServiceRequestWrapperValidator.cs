using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.AdditionalService;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.AdditionalService
{
    public class AdditionalServiceRequestWrapperValidator : AbstractValidator<AdditionalServiceRequestWrapper>
    {
        public AdditionalServiceRequestWrapperValidator(
            IRepository<DAL.Entity.CinemaEntity.AdditionalService> additionalServiceRepository)
        {
            RuleFor(x => x.Id).AdditionalServiceMustExistAsync(additionalServiceRepository);
        }
    }
}