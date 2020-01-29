using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb
{
    public class LanguageAttribute : ActionFilterAttribute
      {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = filterContext.RouteData.Values["lang"] != null ? filterContext.RouteData.Values["lang"].ToString() : "tr";

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            base.OnActionExecuting(filterContext);
        }
    

    }
}