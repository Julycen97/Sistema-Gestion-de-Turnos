using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Persona
    {
        public Persona()
        {
            this.Nombre = "No Nombre";
            this.Apellido = "No Apellido";
            this.DNI = 0;
            this.Direccion = new Domicilio();
            this.Sexo = "No Sexo";
            this.FechaNacimiento = new DateTime(1,1,1900);
        }

        public Persona(string Nombre, string Apellido, int DNI, Domicilio Direccion, string Sexo, DateTime FechaNacimiento)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.DNI = DNI;
            this.Direccion = Direccion;
            this.Sexo = Sexo;
            this.FechaNacimiento = FechaNacimiento;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public Domicilio Direccion { get; set; }
        public string Sexo { get; set; }
        [DisplayName ("Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("   DATOS PERSONALES\n");
            retorno.Append("Nombre:     " + this.Nombre + "\n");
            retorno.Append("Apellido :  " + this.Apellido + "\n");
            retorno.Append("DNI:        " + this.DNI + "\n");
            retorno.Append("Sexo:       " + this.Sexo + "\n");
            retorno.Append("Nacimiento: " + this.FechaNacimiento.ToString());
            retorno.Append(this.Direccion.ToString());
            
            return retorno.ToString();
        }
    }
}