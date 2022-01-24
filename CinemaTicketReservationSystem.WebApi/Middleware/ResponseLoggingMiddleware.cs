using System.IO;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.WebApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CinemaTicketReservationSystem.WebApi.Middleware
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(
            RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value != null && context.Request.Path.Value.Contains("/images/"))
            {
                await _next(context);
                return;
            }

            var originalBodyStream = context.Response.Body;

            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);
            var formatResponse = await FormatResponse(context.Response);
            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
            if (formatResponse != null && formatResponse.Errors != null && !formatResponse.Success)
            {
                foreach (var error in formatResponse.Errors)
                {
                    _logger.LogError(error);
                }
            }

            await responseBody.CopyToAsync(originalBodyStream);
        }

        private async Task<Response> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            Response customResponse = null;
            try
            {
                customResponse = JsonConvert.DeserializeObject<Response>(text);
                response.Body.Seek(0, SeekOrigin.Begin);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                _logger.LogError("Deserialize object error");
            }

            return customResponse;
        }
    }
}