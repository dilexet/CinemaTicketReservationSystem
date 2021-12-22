using System.Collections.Generic;
using System.Linq;
using CinemaTicketReservationSystem.WebApi.Models.Response;
using CinemaTicketReservationSystem.WebApi.Models.Response.ValidationDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CinemaTicketReservationSystem.WebApi.Services
{
    public class CustomValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<ModelValidationDetails> errors = new List<ModelValidationDetails>();

                foreach (var modelState in context.ModelState)
                {
                    errors.Add(new ModelValidationDetails()
                    {
                        Field = modelState.Key,
                        Errors = modelState.Value.Errors.Select(x => x.ErrorMessage)
                    });
                }

                context.Result = new BadRequestObjectResult(new Response()
                {
                    Code = StatusCodes.Status400BadRequest,
                    Success = false,
                    Errors = errors
                });
            }
        }
    }
}