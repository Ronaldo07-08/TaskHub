using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;

namespace Api.Hw.Filters_task
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequestLoggingFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<RequestLoggingFilter>>();

            var method = context.HttpContext.Request.Method;
            var path = context.HttpContext.Request.Path;

            logger.LogInformation($"Выполнение экшена: {method} {path}");

            var stopwatch = Stopwatch.StartNew();
            var executedContext = await next();
            stopwatch.Stop();


            int statusCode = 200; 
            if (executedContext.Result is IStatusCodeActionResult statusCodeResult && statusCodeResult.StatusCode != null)
            {
                statusCode = statusCodeResult.StatusCode.Value;
            }

            logger.LogInformation($"Завершение экшена: Статус {statusCode}, Время {stopwatch.ElapsedMilliseconds} мс");   
        }
    }
}
