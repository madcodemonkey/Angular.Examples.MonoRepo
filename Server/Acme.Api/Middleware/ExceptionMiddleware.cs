using System.Net;
using System.Text.Json;
using Acme.Models.Exceptions;

namespace TodoWebSite.Middleware;

// This middleware is added in the program.cs with this line: app.UseMiddleware<ExceptionMiddleware>();

/// <summary>A middleware class designed to handle uncaught errors.</summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    /// <summary>Constructor</summary>
    public ExceptionMiddleware(RequestDelegate next,
        ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    /// <summary>This method is called as part of the pipeline.  We are just passing it along to the next thing
    /// in the pipeline, but if an uncaught error occurs, it should bubble all the way back to here and get
    /// interpreted by this code.  If it's a user error, we return the appropriate code; otherwise, we cover it
    /// up with an internal 500 error so that things aren't revealed to the caller.  The only exception is when
    /// we are in DEV mode, we bubble the exception and stack trace back to the caller.</summary>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "");
            context.Response.ContentType = "application/json";

            ExceptionMiddlewareMessage response;
            if (ex is ArgumentException || ex is ArgumentNullException)
            {
                response = new ExceptionMiddlewareMessage(context.Response.StatusCode, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (ex is RuleViolationException)
            {
                response = new ExceptionMiddlewareMessage(context.Response.StatusCode, (ex as RuleViolationException).UserFriendlyMessage);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                response = _env.IsDevelopment() ? 
                    new ExceptionMiddlewareMessage(context.Response.StatusCode, ex.Message, ex.StackTrace) : 
                    new ExceptionMiddlewareMessage(context.Response.StatusCode, "Internal Server Error");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}