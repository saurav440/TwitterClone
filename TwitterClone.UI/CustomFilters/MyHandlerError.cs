using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwitterClone.UI.CustomFilters
{
    public class MyHandlerError :HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            Exception ex = filterContext.Exception;
            string controller = filterContext.RouteData.Values["Controller"].ToString();
            string action = filterContext.RouteData.Values["Action"].ToString();
            var obj = new HandleErrorInfo(ex, controller, action);
            Logger.WriteLog(obj);
            base.OnException(filterContext);
        }
    }
}