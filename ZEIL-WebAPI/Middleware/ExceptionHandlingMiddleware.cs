using System.Net;

namespace ZEIL_WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _currentEnv;
        public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _currentEnv = env;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string content = "Internal Server Error";

            if (_currentEnv.IsDevelopment())
            {
                content = "Internal Server Error: " + exception.Message + "\r\n" + exception.StackTrace;
            }

            await context.Response.WriteAsync(new CustomError()
            {
                StatusCode = context.Response.StatusCode,
                Message = content
            }.ToString());

        }
    }
}
