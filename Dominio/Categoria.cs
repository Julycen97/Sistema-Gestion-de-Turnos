using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Categoria
    {
        public Categoria()
        {
            this.Nombre = "No Categoria";
            this.Descripcion = "No Descripcion";
        }

        public Categoria(int IDCategoria, string Nombre, string Descripcion)
        {
            this.IDCategoria = IDCategoria;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }

        [DisplayName ("ID")]
        public int IDCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("Categoria Turno: " + this.Nombre + "\n");
            retorno.Append("Descripcion:     " + this.Descripcion + "\n");

            return retorno.ToString();
        }
    }
}