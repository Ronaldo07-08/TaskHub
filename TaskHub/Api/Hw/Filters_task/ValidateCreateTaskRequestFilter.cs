using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Hw.Filters_task
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidateCreateTaskRequestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.ActionArguments.Values.OfType<CreateTaskRequest>().FirstOrDefault();

            if (request == null)
            {
                context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
                return;
            }

            if (request.UserId == Guid.Empty)
            {
                context.Result = new BadRequestObjectResult("Идентификатор пользователя не задан");
                return;
            }

            if (string.IsNullOrWhiteSpace(request.TaskTitle))
            {
                context.Result = new BadRequestObjectResult("Название задачи не задано");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
