using System.Collections.Generic;
using System.Linq;
using CinemaTicketReservationSystem.WebApi.Models.Response.Validation;
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
                IDictionary<string, IEnumerable<object>> errors = new Dictionary<string, IEnumerable<object>>();

                foreach (var modelState in context.ModelState)
                {
                    errors.Add(modelState.Key, modelState.Value.Errors.Select(modelError => modelError.ErrorMessage));
                }

                context.Result = new BadRequestObjectResult(new ModelValidationResponse()
                {
                    Code = StatusCodes.Status400BadRequest,
                    Success = false,
                    Errors = errors
                });
            }
        }
    }
}