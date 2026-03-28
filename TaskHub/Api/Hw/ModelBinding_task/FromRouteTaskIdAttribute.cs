using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Api.Hw.ModelBinding_task
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromRouteTaskIdAttribute : ModelBinderAttribute
    {
        public FromRouteTaskIdAttribute() 
        {
            BinderType = typeof(FromRouteTaskIdBinder);

            BindingSource = BindingSource.Path;
        }
    }
}
