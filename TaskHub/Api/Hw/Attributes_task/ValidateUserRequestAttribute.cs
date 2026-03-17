using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Validation;
using System.ComponentModel.DataAnnotations;

namespace Api.Hw.Attributes_task
{
    public class ValidateUserRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ActionArguments.TryGetValue("request", out var reqObj) || reqObj is null)
            {
                context.Result = new BadRequestObjectResult("Тело запроса отутствует");
                return; 
            }

            var propName = reqObj.GetType().GetProperty("Name");

            if (propName != null)
            {
                var value = propName.GetValue(reqObj) as string;
                if (string.IsNullOrWhiteSpace(value))
                {
                    context.Result = new BadRequestObjectResult("Имя пользователя не задано");
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
