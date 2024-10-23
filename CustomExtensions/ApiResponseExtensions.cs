using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;
using MyBlog.Models;

namespace MyBlog.CustomExtensions
{
    public static class ApiResponseExtensions
    {

        public static ApiResponse<T> FailInValidateModel<T>(this ModelStateDictionary modelState)
        {
            var errors = modelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
            );

            return CreateErrorResponse<T>("Falha na validação do modelo", errors);
        }

        public static ApiResponse<T> FailInValidateFluentModel<T>(this ValidationResult validationResult)
        {
            var errors = validationResult.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToList()
                );

            return CreateErrorResponse<T>("Falha na validação do modelo", errors);
        }

        private static ApiResponse<T> CreateErrorResponse<T>(string message, Dictionary<string, List<string>> errors)
        {
            return new ApiResponse<T>
            {
                Message = message,
                StatusCode = 400,
                data = default(T),
                IsSuccessful = false,
                Errors = errors ?? new Dictionary<string, List<string>>()
            };
        }
    }
}
