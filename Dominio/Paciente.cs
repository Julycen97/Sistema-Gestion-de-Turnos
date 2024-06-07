using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Paciente : Persona
    {
        public Paciente()
        {
            this.NumPaciente = 0;
            this.FechaAfiliacion = new DateTime(1, 1, 1900);
            this.Cobertura = "No Cobertura";
        }

        public Paciente(Persona datosPers, int NumPaciente, DateTime FechaAfiliacion, string Cobertura)
        {
            this.Nombre = datosPers.Nombre;
            this.Apellido = datosPers.Apellido;
            this.DNI = datosPers.DNI;
            this.Direccion = datosPers.Direccion;
            this.Sexo = datosPers.Sexo;
            this.FechaNacimiento = datosPers.FechaNacimiento;

            this.NumPaciente = NumPaciente;
            this.FechaAfiliacion = FechaAfiliacion;
            this.Cobertura = Cobertura;
        }

        [DisplayName ("Numero de Paciente")]
        public int NumPaciente { get; set; }
        [DisplayName ("Fecha de Afiliacion")]
        public DateTime FechaAfiliacion { get; set; }
        public string Cobertura { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("    DATOS DEL PACIENTE\n");
            retorno.Append("Numero de Paciente:  " + this.NumPaciente + "\n");
            retorno.Append("Fecha de Afiliacion: " + this.FechaAfiliacion.ToString() + "\n");
            retorno.Append("Cobertura:           " + this.Cobertura + "\n");
            //CHUSMEAR
            retorno.Append(base.ToString());

            return retorno.ToString();
        }
    }
}