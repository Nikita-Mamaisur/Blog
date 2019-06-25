using System.Web.Mvc;
using System.Web.Routing;

namespace Blog
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PostsShow",
                url: "posts/show/{slug}",
                defaults: new { controller = "Posts", action = "Show" }
            );

            routes.MapRoute(
                name: "Error",
                url: "error/{statusCode}",
                defaults: new { controller = "Error", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
