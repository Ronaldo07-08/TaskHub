using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Hw.ModelBinding_task
{
    public class FromRouteTaskIdBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == ValueProviderResult.None || string.IsNullOrWhiteSpace(value.FirstValue))
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Идентификатор задачи не задан");
                return Task.CompletedTask;  
            }

            var id = value.FirstValue;

            Guid parsedId;
            if (!Guid.TryParse(id, out parsedId))
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Идентификатор задачи имеет некорректный формат");
            else
                bindingContext.Result = ModelBindingResult.Success(parsedId);

            return Task.CompletedTask;
        }
    }
}
