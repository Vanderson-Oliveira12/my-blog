namespace MyBlog.MIddlewares
{
    public class HandleExceptionGlobalMiddleware
    {
        public ILogger<HandleExceptionGlobalMiddleware> _logger { get; set; }
        public RequestDelegate _next { get; set; }

        public HandleExceptionGlobalMiddleware(ILogger<HandleExceptionGlobalMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
               await _next(context);    
            }
            catch ( Exception ex ) {

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = new
                {
                   Message = "Erro interno do servidor",
                   StatusCode = 500,
                   ErrorDetail = ex.Message,
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
