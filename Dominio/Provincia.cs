using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Provincia
    {
        public Provincia()
        {
            this.IDProvincia = 0;
            this.Nombre = "No Cobertura";
        }

        public Provincia(int IDProvincia, string Nombre)
        {
            this.IDProvincia = IDProvincia;
            this.Nombre = Nombre;
        }

        public int IDProvincia { get; set; }
        [DisplayName("Provincia")]
        public string Nombre { get; set; }

        public override string ToString()
        {
            return "Provincia: " + this.Nombre;
        }
    }
}