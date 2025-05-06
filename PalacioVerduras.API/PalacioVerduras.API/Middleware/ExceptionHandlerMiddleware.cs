using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace PalacioVerduras.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;
            var stackTrace = string.Empty;

            switch (ex)
            {
                case KeyNotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;
                case ArgumentException:
                    status = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Error interno del servidor.";
                    stackTrace = ex.StackTrace; 
                    break;
            }

            _logger.LogError(ex, message); 

            var errorResponse = new
            {
                StatusCode = (int)status,
                Message = message,
                StackTrace = stackTrace  
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            var json = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(json);
        }
    }
}