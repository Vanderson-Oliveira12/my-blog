﻿namespace MyBlog.DTOs
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; } = 0;
        public bool IsSuccessful { get; set; }
        public T data { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        public static ApiResponse<T> Success(T data, string message = "Ok", int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Message = message,
                StatusCode = statusCode,
                data = data,
                IsSuccessful = true
            };
        }

        public static ApiResponse<T> Fail(string message = "Falha na requisição", int statusCode = 400, Dictionary<string, List<string>> errors = null)
        {
            return new ApiResponse<T>
            {
                Message = message,
                StatusCode = statusCode,
                data = default,
                IsSuccessful = false,
                Errors = errors ?? new Dictionary<string, List<string>>()
            };
        }
    }
}
