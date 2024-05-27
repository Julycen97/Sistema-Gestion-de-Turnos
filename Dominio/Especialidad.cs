using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Especialidad
    {
        public Especialidad()
        {
            this.Nombre = "No Especialidad";
            this.Rama = "No Rama";
        }

        public Especialidad(int IDEspecialidad, string Nombre, string Rama)
        {
            this.IDEspecialidad = IDEspecialidad;
            this.Nombre = Nombre;
            this.Rama = Rama;
        }
        [DisplayName ("ID")]
        public int IDEspecialidad { get; set; }
        public string Nombre { get; set; }
        public string Rama { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("Especialidad: " + this.Nombre + "\n");
            retorno.Append("Rama:         " + this.Rama + "\n");
            return retorno.ToString();
        }
    }
}