using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Wrappers.Cinema;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Cinema
{
    public class CinemaRequestWrapperValidator : AbstractValidator<CinemaRequestWrapper>
    {
        public CinemaRequestWrapperValidator(IRepository<DAL.Entity.CinemaEntity.Cinema> cinemaRepository)
        {
            RuleFor(x => x.Id).CinemaMustExistAsync(cinemaRepository);
        }
    }
}