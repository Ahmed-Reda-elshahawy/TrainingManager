
namespace TrainingManager.Middlewares
{
    public class HelloMiddleware(ILogger<HelloMiddleware> logger, RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation("hello");
            await next(context);
        }
    }

    public static class HelloMillewareExtention
    {
        public static IApplicationBuilder UseHelloMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloMiddleware>();
        }
    }
}
