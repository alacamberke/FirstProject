using Dal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace NormalApi.Logging
{
    public class LoggingAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var sb = new StringBuilder();
            foreach (var parameter in actionContext.ActionArguments)
            {
                sb.Append($"{parameter.Key} = {parameter.Value}");
            }
            
            using (Context context = new Context())
            {
                LogClass log = new LogClass();
                log.IsBefore = true;
                log.LogCaption = $"{actionContext.ControllerContext.ControllerDescriptor.ControllerName} - "
                    + $"{ actionContext.ActionDescriptor.ActionName}";
                log.Date = DateTime.Now;
                log.LogArgumentDetail = sb.ToString();

                context.Logs.Add(log);
                context.SaveChanges();
            }

            base.OnActionExecuting(actionContext);
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            using (Context context = new Context())
            {
                LogClass log = new LogClass();
                log.IsBefore = false;
                log.LogCaption = $"{actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName} - " +
                    $"{actionExecutedContext.ActionContext.ActionDescriptor.ActionName}";
                log.Date = DateTime.Now;
                log.LogArgumentDetail = "";

                context.Logs.Add(log);
                context.SaveChanges();
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}