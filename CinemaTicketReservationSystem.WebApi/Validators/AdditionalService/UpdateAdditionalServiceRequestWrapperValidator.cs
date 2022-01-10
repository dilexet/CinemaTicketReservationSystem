using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.AdditionalService;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.AdditionalService
{
    public class
        UpdateAdditionalServiceRequestWrapperValidator : AbstractValidator<UpdateAdditionalServiceRequestWrapper>
    {
        public UpdateAdditionalServiceRequestWrapperValidator(
            IRepository<DAL.Entity.CinemaEntity.Cinema> cinemaRepository)
        {
            RuleFor(x => x.AdditionalServiceRequest).SetValidator(new AdditionalServiceRequestValidator());
            RuleFor(x => x.CinemaId).CinemaMustExistAsync(cinemaRepository);
            RuleFor(x => x).AdditionalServiceMustExistInCinemaAsync(cinemaRepository);
        }
    }
}