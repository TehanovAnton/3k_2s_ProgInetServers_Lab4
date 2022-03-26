using System.Web.Mvc;
using System.Web.Routing;

namespace lab3_mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "DictIndex",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Index" } 
            );


            routes.MapRoute(
                name: "DictAdd",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Add" }
            );
            routes.MapRoute(
                name: "DictAddSave",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "AddSave" }
            );


            routes.MapRoute(
                name: "DictUpdate",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Update" }
            );
            routes.MapRoute(
                name: "DictUpdateSave",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "DictUpdateSave" }
            );


            routes.MapRoute(
                name: "DictDelete",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Delete" }
            );
            routes.MapRoute(
                name: "DictDeleteSave",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "DeleteSave" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
