using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Student_MVC
{
    public class PreventFromUrl
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class PreventByCustomer : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {

                var canAcess = false;

                // check the refer
                var referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();
                if (!string.IsNullOrEmpty(referer))
                {
                    var rUri = new System.UriBuilder(referer).Uri;
                    var req = filterContext.HttpContext.Request;
                    if (req.Host.Host == rUri.Host && req.Host.Port == rUri.Port && req.Scheme == rUri.Scheme)
                    {
                        canAcess = true;
                    }
                }

                // ... check other requirements

                if (!canAcess)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "CustomerLoginPage", area = "" }));
                }
            }
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class PreventByAdmin : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {

                var canAcess = false;

                // check the refer
                var referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();
                if (!string.IsNullOrEmpty(referer))
                {
                    var rUri = new System.UriBuilder(referer).Uri;
                    var req = filterContext.HttpContext.Request;
                    if (req.Host.Host == rUri.Host && req.Host.Port == rUri.Port && req.Scheme == rUri.Scheme)
                    {
                        canAcess = true;
                    }
                }

                // ... check other requirements

                if (!canAcess)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "AdminLoginPage", area = "" }));
                }
            }
        }
    }
}
