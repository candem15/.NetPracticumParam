using Hafta2.Odev2.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hafta2.Odev2.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RequireUserLoginAttribute : ActionFilterAttribute
    {
        private const string HeaderKey = "login-key";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionDescriptor.FilterDescriptors.Any(x => x.Filter.GetType() == typeof(RequireUserLoginAttribute)))
                return;

            var header = context.HttpContext.Request.Headers;

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            if (header == null || !header.Any() || !header.ContainsKey(HeaderKey) || configuration["Auth:LoginKey"] != header[HeaderKey].ToString())
                throw new MissingLoginKeyException();

        }
    }
}
