using System.Globalization;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.Configuration(BundleTable.Bundles);

            var cultureUa = CultureInfo.CreateSpecificCulture("uk");
            CultureInfo.DefaultThreadCurrentCulture = cultureUa;
            CultureInfo.DefaultThreadCurrentUICulture = cultureUa;
        }
    }
}
