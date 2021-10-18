using System;
using MassageSalon.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MassageSalon.WEB.Filters
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;
            string errorMessage = $"In action {actionName} invoked exception: \n {exceptionMessage} \n {exceptionStack}";

            var logger = context.HttpContext.RequestServices.GetService<ILoggerService>();
            logger.LogError(errorMessage);
            context.ExceptionHandled = true;
            context.HttpContext.Response.Redirect("/Offer/Index");
        }
    }
}
