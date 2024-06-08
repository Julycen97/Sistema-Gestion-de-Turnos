using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Cobertura
    {
        public Cobertura()
        {
            this.IDCobertura = 0;
            this.Nombre = "No Cobertura";
        }

        public Cobertura(int IDCobertura, string Nombre)
        {
            this.IDCobertura = IDCobertura;
            this.Nombre = Nombre;
        }

        public int IDCobertura { get; set; }
        [DisplayName("Cobertura")]
        public string Nombre { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("    DATOS COBERTURA\n");
            retorno.Append("ID:     " + this.IDCobertura + "\n");
            retorno.Append("Nombre: " + this.Nombre + "\n");

            return retorno.ToString();
        }
    }
}