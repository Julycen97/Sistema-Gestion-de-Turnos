using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Ciudad
    {
        public Ciudad()
        {
            this.IDCiudad = 0;
            this.IDProvincia = 0;
            this.Nombre = "No Cobertura";
        }

        public Ciudad(int IDCiudad, int IDProvincia, string Nombre)
        {
            this.IDCiudad = IDCiudad;
            this.IDProvincia = IDProvincia;
            this.Nombre = Nombre;
        }

        public int IDCiudad { get; set; }
        public int IDProvincia { get; set; }
        [DisplayName("Ciudad")]
        public string Nombre { get; set; }

        public override string ToString()
        {
            return "Ciudad: " + this.Nombre;
        }
    }
}