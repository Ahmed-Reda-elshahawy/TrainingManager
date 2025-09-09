namespace TrainingManager.Middlewares;

public class CustomConventionalMiddleware(ILogger<CustomConventionalMiddleware> logger, RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        if(context.Request.Query.ContainsKey("firstname") && context.Request.Query.ContainsKey("lastname"))
        {
            var firstName = context.Request.Query["firstname"].ToString();
            var lastName = context.Request.Query["lastname"].ToString();
            logger.LogInformation($"Hello {firstName} {lastName} from conventional middleware!");
        }
        else
        {
            logger.LogInformation("Hello from conventional middleware!");
        }
        //logger.LogInformation("Custom conventional middleware is processing the request.");
        await next(context); // Calls the next middleware in the pipeline.
        //logger.LogInformation("Custom conventional middleware has finished processing the request.");
    }
}

public static class CustomConventionalMiddlewareExtension
{
    public static IApplicationBuilder UseCustomConventionalMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomConventionalMiddleware>();
    }
}