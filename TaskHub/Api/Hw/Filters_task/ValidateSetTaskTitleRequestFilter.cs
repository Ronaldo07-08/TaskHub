using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Hw.Filters_task
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidateSetTaskTitleRequestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.ActionArguments.Values.OfType<SetTaskTitleRequest>().FirstOrDefault();
    
            if (request == null)
            {
                context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
