using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FootbalTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // PSGController
            routes.MapRoute(
                name: "PSG",
                url: "PSG/{action}/{id}",
                defaults: new { controller = "PSG", action = "GetPlayersPSG", id = UrlParameter.Optional }
            );

            // BesiktasController
            routes.MapRoute(
                name: "Besiktas",
                url: "Besiktas/{action}/{id}",
                defaults: new { controller = "Besiktas", action = "GetPlayersBesiktas", id = UrlParameter.Optional }
            );

            // HomeController
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }



    }
}
