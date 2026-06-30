
using Resturants.Domain.Exceptions;

namespace Resturants.API.Middlewares
{
    public class GlobalExceptionMiddle(ILogger<GlobalExceptionMiddle> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch (NotFoundExceptions exception)
			{
				context.Response.StatusCode = 404;
				await context.Response.WriteAsync(exception.Message);
				logger.LogWarning(exception.Message);
			}
			catch (ForbidException)
			{
				context.Response.StatusCode = 403;
				await context.Response.WriteAsync("Access Forbidden!");
			}
			catch (Exception ex)
			{
				logger.LogError(ex,ex.Message);
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync("Something goes wrong!");

				
			}
        }
    }
}
