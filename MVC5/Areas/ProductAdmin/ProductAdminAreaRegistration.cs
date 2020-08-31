using System.Web.Mvc;

namespace MVC5.Areas.ProductAdmin
{
    public class ProductAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName  { get  {return "ProductAdmin"; } }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProductAdmin_default",
                "productadmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}