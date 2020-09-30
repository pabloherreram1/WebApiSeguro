using System;
using System.Runtime.Serialization;

namespace WebApiSegura.Models
{
    [DataContract]
    public class LoginRequest
    {
        [DataMember(Name = "rut")]
        public string rut { get; set; }

        public LoginRequest(string rut)
        {
            this.rut = rut;

        }
    }

    
}