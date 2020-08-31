using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVC5.CustomClass 
{
    public class Auth : ActionFilterAttribute, IAuthenticationFilter
    {
        private string role = string.Empty;
        public Auth()
        {
            // default constructor
        }

        public Auth(string role)
        {
            this.role = role;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
            {
                controller = "Index",
                action = "Login",
                returnUrl = filterContext.HttpContext.Request.Url.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped)
            }));
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Login",
                }));
            }
        }
    }
}