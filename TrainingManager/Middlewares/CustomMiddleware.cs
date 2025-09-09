
namespace TrainingManager.Middlewares;

public class CustomMiddleware(ILogger<CustomMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        logger.LogInformation("Custom middleware is processing the request.");
        await next(context); // Calls the next middleware in the pipeline.
        logger.LogInformation("Custom middleware has finished processing the request.");
    }
}

public static class CustomMiddlewareExtension
{
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }
}