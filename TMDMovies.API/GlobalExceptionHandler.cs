using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TMDMovies.Commons.Exceptions;

namespace TMDMovies.API
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            this.logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;
            logger.LogError($"Error Message: {exceptionMessage}, Time of occurrence {DateTime.UtcNow}");

            int httpStatus;
            string title;
            switch (exception)
            {
                case InstanceNotFoundException ine:
                    httpStatus = (int)HttpStatusCode.NotFound;
                    title = "Instance not found";
                    break;
                default:
                    httpStatus = (int)HttpStatusCode.InternalServerError;
                    title = "An unexpected error occurred";
                    break;
            }
            httpContext.Response.StatusCode = httpStatus;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = httpStatus,
                Type = exception.GetType().Name,
                Title = title,
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            });

            return true;
        }
    }
}
