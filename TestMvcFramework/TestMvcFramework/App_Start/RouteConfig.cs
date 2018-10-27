using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestMvcFramework
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                    "Blog",                                                                                                             // Route name
                    "{controller}/{action}/{id}/{type}",                                                                                // URL with parameters
                    new { controller = "Home", action = "RouteTest", id = UrlParameter.Optional, type = UrlParameter.Optional }         // Parameter defaults
                );
        }
    }
}
