using System.Web.Mvc;
using System.Web.Routing;
using MVC5.Controllers;

namespace MVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            string[] namespaceAccount = new[] {typeof(AccountController).Namespace};
            string[] namespaceIndex = new[] {typeof(IndexController).Namespace};
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("login", "", new {controller = "Account",action="Login"  },namespaceAccount);
            routes.MapRoute("login1", "login", new {controller = "Account",action="Login"  },namespaceAccount);
            routes.MapRoute("signout", "signout", new {controller = "Account",action="logout"  },namespaceAccount);
            routes.MapRoute("register", "register", new {controller = "Account",action="register"  },namespaceAccount);

            routes.MapRoute("Indexhome", "home/{action}", new {controller = "Index",action="Home"  },namespaceIndex);
            
        }
    }
}
