using Microsoft.Extensions.Primitives;

namespace ZEIL_WebAPI.Middleware
{
    public class APIKeyValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string KEY_NAME = "X-Api-Key";
        public APIKeyValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            StringValues callerAPIKey = "";
            bool valid = false;

            if (context.Request.Headers.TryGetValue(KEY_NAME, out callerAPIKey))
            {
                var serverAPIKey = Environment.GetEnvironmentVariable(KEY_NAME, EnvironmentVariableTarget.User); //since requirement is "production" level, use environment variable
                if (callerAPIKey.Count == 1 && callerAPIKey.Equals(serverAPIKey))
                {
                    valid = true;
                    await _next(context);
                }
            }

            if (!valid)
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(new CustomError()
                {
                    StatusCode = (int)StatusCodes.Status401Unauthorized,
                    Message = "Unauthorized"
                }.ToString());
            }

            return;
        }
    }
}
