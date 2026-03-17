using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Hw.Attributes_task
{
    public class ResponseTimeHeaderAttribute : ActionFilterAttribute
    {

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ws = Stopwatch.StartNew();

            await next();

            ws.Stop();
            var timeElapsed = ws.ElapsedMilliseconds.ToString();
            Console.WriteLine($"-----------------time elapsed ->{timeElapsed}--------------");
            context.HttpContext.Response.Headers.Append("X-Response-Time-Ms", ws.ElapsedMilliseconds.ToString());
        }
    }
}
