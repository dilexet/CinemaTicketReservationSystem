using System;
using System.Data.Common;
using AutoMapper;
using CinemaTicketReservationSystem.WebApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CinemaTicketReservationSystem.WebApi.CustomFilters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            Response response = new Response();

            var exceptionType = context.Exception.GetType();
            _logger.LogError(context.Exception, context.Exception.Message);
            if (exceptionType == typeof(AutoMapperMappingException))
            {
                response.Code = StatusCodes.Status500InternalServerError;
                response.Success = false;
                response.Errors = new[]
                {
                    context.Exception.Message
                };
            }
            else if (exceptionType == typeof(ArgumentNullException))
            {
                response.Code = StatusCodes.Status500InternalServerError;
                response.Success = false;
                response.Errors = new[]
                {
                    context.Exception.Message
                };
            }
            else if (exceptionType == typeof(SqlException))
            {
                response.Code = StatusCodes.Status500InternalServerError;
                response.Success = false;
                response.Errors = new[]
                {
                    context.Exception.Message
                };
            }
            else if (exceptionType == typeof(DbException))
            {
                response.Code = StatusCodes.Status500InternalServerError;
                response.Success = false;
                response.Errors = new[]
                {
                    context.Exception.Message
                };
            }
            else
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