using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Domicilio
    {
        public Domicilio()
        {
            this.IDDomicilio = 0;
            this.Calle = "No Calle";
            this.Altura = 0;
            this.Ciudad = new Ciudad();
            this.CodPostal = 0;
        }

        public Domicilio(int IDDomicilio, string Calle, int Altura, Ciudad Ciudad, string Provincia, int CodPostal)
        {
            this.IDDomicilio = IDDomicilio;
            this.Calle = Calle;
            this.Altura = Altura;
            this.Ciudad = Ciudad;
            this.CodPostal = CodPostal;
        }
        [DisplayName ("ID")]
        public int IDDomicilio { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public Ciudad Ciudad { get; set; }
        [DisplayName("Código Postal")]
        public int CodPostal { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("        DATOS DE DOMICILIO\n");
            retorno.Append("Calle:         " + this.Calle + "\n");
            retorno.Append("Altura:        " + this.Altura + "\n");
            retorno.Append("Ciudad:        " + this.Ciudad.Nombre + "\n");
            retorno.Append("Codigo Postal: " + this.CodPostal + "\n");

            return retorno.ToString();
        }
    }
}