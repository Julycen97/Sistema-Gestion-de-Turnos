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
            this.Ciudad = "No Ciudad";
            this.Provincia = "No Provincia";
            this.CodPostal = 0;
        }

        public Domicilio(int IDDomicilio, string Calle, int Altura, string Ciudad, string Provincia, int CodPostal)
        {
            this.IDDomicilio = IDDomicilio;
            this.Calle = Calle;
            this.Altura = Altura;
            this.Ciudad = Ciudad;
            this.Provincia = Provincia;
            this.CodPostal = CodPostal;
        }
        [DisplayName ("ID")]
        public int IDDomicilio { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        [DisplayName("Código Postal")]
        public int CodPostal { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("        DATOS DE DOMICILIO\n");
            retorno.Append("Calle:         " + this.Calle + "\n");
            retorno.Append("Altura:        " + this.Calle + "\n");
            retorno.Append("Ciudad:        " + this.Calle + "\n");
            retorno.Append("Provincia:     " + this.Calle + "\n");
            retorno.Append("Codigo Postal: " + this.Calle + "\n");

            return retorno.ToString();
        }
    }
}