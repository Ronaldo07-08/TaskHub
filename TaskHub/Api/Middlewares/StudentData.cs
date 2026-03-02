using System.Net;
using System.Text;

namespace Api.Middlewares
{
    public class StudentData
    {
        private readonly RequestDelegate _next;

        public StudentData(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            context.Response.Headers["X-Student-Name"] = "Ivanov Dmitri Igorevich";
            context.Response.Headers["X-Student-Group"] = "Ri-240946";

            
            await _next(context);
        }

    }
}
