
using System.Diagnostics;

namespace Resturants.API.Middlewares
{
    public class TimeLoggingMiddle(ILogger<TimeLoggingMiddle> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await next.Invoke(context);
            
            stopwatch.Stop();
            if(stopwatch.ElapsedMilliseconds / 1000 == 4)
            {
                logger.LogInformation($"request upond 4 seconds , it's verb: {context.Request.Method} , and path: {context.Request.Path},time: {stopwatch.ElapsedMilliseconds}");
            }


        }
    }
}
