using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Hw.Attributes_task
{
    public class StudentInfoHeadersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Append("X-Student-Name", "Ivanov Dmitri Igorevich");
            context.HttpContext.Response.Headers.Append("X-Student-Group", "Ri-240946");

            base.OnActionExecuting(context);
        }
    }
}
