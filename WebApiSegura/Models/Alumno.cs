using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiSegura.Models
{
    [DataContract]
    public class Alumno
    {
        [DataMember(Name = "rut")]
        public string Rut { get; set; }
        [DataMember(Name = "mail")]
        public string Mail { get; set; }
        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }
        [DataMember(Name = "apellido")]
        public string Apellido { get; set; }
        [DataMember(Name = "pass")]
        public string Pass { get; set; }
        [DataMember(Name = "code")]
        public string Code { get; set; }

        public Alumno(string rut, string mail, string nombre, string apellido, string pass, string code)
        {
            this.Rut = rut;
            this.Mail = mail;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Pass = pass;
            this.Code = code;
        }

        public Alumno(string rut, string pass)
        {
            this.Rut = rut;
            this.Pass = pass;

        }

        public Alumno(string rut)
        {
            this.Rut = rut;

        }
    }
}