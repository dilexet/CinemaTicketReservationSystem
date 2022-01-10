using System;
using System.IO;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CinemaTicketReservationSystem.WebApi.Extensions.FluentValidator
{
    public static class FormFileRuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, IFormFile> FileMustBeImage<T>(
            this IRuleBuilder<T, IFormFile> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .Must(file =>
                {
                    if (!string.Equals(file.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(file.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(file.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }

                    var fileExtension = Path.GetExtension(file.FileName);
                    if (!string.Equals(fileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(fileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(fileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }

                    return true;
                })
                .WithName("FileUploaded")
                .WithMessage("File must be of the image content type");
            return options;
        }
    }
}