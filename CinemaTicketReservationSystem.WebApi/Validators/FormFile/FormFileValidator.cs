using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.FormFile
{
    public class FormFileValidator : AbstractValidator<Microsoft.AspNetCore.Http.FormFile>
    {
        public FormFileValidator()
        {
            RuleFor(x => x).FileMustBeImage();
        }
    }
}