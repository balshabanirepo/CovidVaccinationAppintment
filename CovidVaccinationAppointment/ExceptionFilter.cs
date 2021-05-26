using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace CovidVaccinationAppointment
{
    public class ExceptionFilter:ExceptionFilterAttribute,IExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new RedirectResult("~/Home/ExceptionHandler?ErrorMessage="+context.Exception.Message);
        }
    }
        //public override void OnActionExecuting(ActionExecutingContext
        //                                   context)
        //{
        //    SystemSettingsRepository systemsettingsrepository;

        //    var user = context.HttpContext.User;
        //    _configuration = (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));
        //    var token = context.HttpContext.Request.Query["Token"];
        //    dbConext = new DbConext();
        //    if (token == "")
        //    {
        //        // throw new UnauthorizedAccessException("Invalid Token");

        //        context.Result = new UnauthorizedResult();

        //    }
        //    systemsettingsrepository = dbConext.SystemSettings.FirstOrDefault();
        //    if (systemsettingsrepository == null)
        //    {
        //        //throw new UnauthorizedAccessException("Invalid Token");
        //        context.Result = new UnauthorizedResult();

        //    }
        //    if (token != systemsettingsrepository.Token)
        //    {
        //        // throw new UnauthorizedAccessException("Invalid Token");
        //        context.Result = new UnauthorizedResult();
        //        // return;
        //    }

        //}
    
}
