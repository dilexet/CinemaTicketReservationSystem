﻿using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator;
using CinemaTicketReservationSystem.WebApi.Models.Requests.Authorize;
using FluentValidation;

namespace CinemaTicketReservationSystem.WebApi.Validators.Authorize
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter the username");
            RuleFor(x => x.Name).Length(5, 16).WithMessage("Username must be between 5 and 16 characters");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter the password");
            RuleFor(x => x.Password).Length(4, 25).WithMessage("Password must be between 4 and 25 characters");
            RuleFor(x => x).LoginMustBeValidAsync(userRepository);
        }
    }
}