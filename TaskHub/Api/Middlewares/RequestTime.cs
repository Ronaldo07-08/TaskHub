using System.Diagnostics;

namespace Api.Middlewares
{
    public class RequestTime
    {

        private readonly RequestDelegate _next;

        public RequestTime(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            sw.Start();
            context.Response.OnStarting( () =>
            {
                sw.Stop();
                context.Response.Headers["X-Response-Time-Ms"] = sw.ElapsedMilliseconds.ToString();
                return Task.CompletedTask;
            });

            await _next(context);

        }
    }
}
