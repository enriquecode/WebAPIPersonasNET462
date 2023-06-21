using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIPersonasNET462
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Personas",
                routeTemplate: "api/personas/{id}",
                defaults: new { controller = "Personas", id = RouteParameter.Optional }
    
                
            );
        }
    }
}
