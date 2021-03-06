﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace small_online_store
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
                name: "Clothing",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Clothing", action = "MenClothing", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BuyClothing",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Clothing", action = "Buy", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Login", Email = UrlParameter.Optional }
            );

           
        }
    }
}
