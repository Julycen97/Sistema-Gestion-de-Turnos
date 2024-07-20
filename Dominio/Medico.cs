using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Medico : Persona
    {
        public Medico()
        {
            this.NumMatricula = 0;
            this.Area = new Especialidad();
            this.Estado = true;
        }

        public Medico(Persona Datos, int NumMatricula, Especialidad Area)
        {
            this.Nombre = Datos.Nombre;
            this.Apellido = Datos.Apellido;
            this.DNI = Datos.DNI;
            this.Direccion = Datos.Direccion;
            this.Sexo = Datos.Sexo;
            this.FechaNacimiento = Datos.FechaNacimiento;

            this.NumMatricula = NumMatricula;
            this.Area = Area;
            this.Estado = true;
        }

        [DisplayName ("Numero de Matricula")]
        public int NumMatricula { get; set; }
        public Especialidad Area { get; set; }
        public bool Estado { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("    DATOS DE MEDICO\n");
            retorno.Append("Numero de Matricula: " + this.NumMatricula + "\n");
            retorno.Append(Area.ToString());
            //CHUSMEAR
            retorno.Append(base.ToString());

            return retorno.ToString();
        }
    }
}