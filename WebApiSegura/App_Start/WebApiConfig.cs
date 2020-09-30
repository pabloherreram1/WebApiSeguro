using System;
using System.Web.Http;
using WebApiSegura.Security;
using MySql.Data.MySqlClient;



namespace WebApiSegura
{
    public static class WebApiConfig
    {
        public static MySqlConnection conn()
        {
            // Aquí se modifican los parámetros de la conexión a phpmyadmin
            string conn_string = "server=localhost;port=3306;database=test;username=root";

            MySqlConnection conn = new MySqlConnection(conn_string);
            return conn;
        }

        public static void Register(HttpConfiguration config)
        {
           
            // Configuración de rutas y servicios de API
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional}
            );
        }

        
    }
}
