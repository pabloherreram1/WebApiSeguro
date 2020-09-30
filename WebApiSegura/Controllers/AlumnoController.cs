using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml;
using WebApiSegura.Models;

namespace WebApiSegura.Controllers
{
    [Authorize]
    [RoutePrefix("api/alumno")]
    public class AlumnoController : ApiController
    {
        [Route("api/alumno/{rut}")]
        [HttpGet]
        public IHttpActionResult GetRut(string rut)
        {
            
            var alumno = new List<Alumno>();
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "Select * from alumno where rut =" + rut;

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {


            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            fetch_query.Read();
            

            alumno.Add(new Alumno(fetch_query["rut"].ToString(),
            fetch_query["mail"].ToString(), fetch_query["nombre"].ToString(), fetch_query["apellido"].ToString(), fetch_query["pass"].ToString(), createCode()));

            return Ok(alumno);   

        }

        public string createCode()
        {
            string code;
            Random n = new Random();
            string[] letters = {"A", "B", "C", "D", "E", "F", "G",
                                "H", "I", "J", "K", "L", "M", "N",
                                "O", "P", "Q", "R", "S", "T", "U",
                                "V", "W", "X", "Y", "Z"
            };

            code = letters[n.Next(1, 26)] + n.Next(1, 9).ToString() + letters[n.Next(1, 26)] + n.Next(1, 9).ToString();
            return code;
        }

        [Route("api/alumno/{rut}")]
        [HttpPut]
        public IHttpActionResult UpdatePass(string rut, string value)
        {
            var alumno = new List<Alumno>();
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "UPDATE alumno SET pass = '" + value + "' where rut =" + rut;

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            fetch_query.Read();
            return Ok(true);
        }
    }
}