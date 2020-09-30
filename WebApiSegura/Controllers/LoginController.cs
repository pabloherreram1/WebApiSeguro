using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Xml.Linq;
using WebApiSegura.Models;
using WebApiSegura.Security;

namespace WebApiSegura.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            var rut = login.rut;
            //var alumno = new List<Alumno>();
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "Select rut from alumno where rut =" + rut;

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {


            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            fetch_query.Read();
            

            var rutalumno = fetch_query["rut"].ToString();

            if (rutalumno == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: This code is only for demo - extract method in new class & validate correctly in your application !!

            var isUserValid = (login.rut == rutalumno);
            if (isUserValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.rut);
                return Ok(token);
            }
            else
            {
                // Unauthorized access 
                return Unauthorized();
            }
        }
    }
}
