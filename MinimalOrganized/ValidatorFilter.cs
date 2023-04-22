using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text.Json;

namespace MinimalOrganized
{
    internal class ValidatorFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var argToValidate = context.GetArgument<T>(0);

            if (argToValidate == null)
            {
                return Results.BadRequest("Request is null");
            }

            var validationResult = new List<ValidationResult>();

            var isValid =
                Validator.TryValidateObject(argToValidate, new ValidationContext(argToValidate), validationResult);

            if (!isValid)
            {
                return Results.BadRequest(JsonSerializer.Serialize(validationResult.Select(vr => vr.ErrorMessage)));
            }

            return await next.Invoke(context);
        }
    }
}