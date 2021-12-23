using AutoMapper;
using CinemaTicketReservationSystem.WebApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CinemaTicketReservationSystem.WebApi.CustomFilters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Response response = new Response();

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(AutoMapperMappingException))
            {
                response.Code = StatusCodes.Status500InternalServerError;
                response.Success = false;
                response.Errors = new[]
                {
                    context.Exception.Message
                };
            }

            context.ExceptionHandled = true;

            HttpResponse httpResponse = context.HttpContext.Response;
            httpResponse.StatusCode = response.Code;
            httpResponse.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(response);
            httpResponse.WriteAsync(result);
        }
    }
}