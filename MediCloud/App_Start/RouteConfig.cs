using System.Web.Mvc;
using System.Web.Routing;

namespace MediCloud.View
{
    public class RouteConfig
    {
        #region Public Methods

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }

        #endregion Public Methods
    }
}