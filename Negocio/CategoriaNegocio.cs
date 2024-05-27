using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class CategoriaNegocio
    {
        private List<Categoria> listaCat;
        private AccesoDatos accesoDatos;
        public CategoriaNegocio()
        {
            this.listaCat = new List<Categoria>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Categoria> ObtenerCategorias()
        {
            try
            {
                this.accesoDatos.SetearComando("SELECT IDCATEGORIA, NOMBRE, DESCRIPCION FROM CATEGORIAS");
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (accesoDatos.getLector.Read())
                {
                    Categoria auxiliar = new Categoria();

                    auxiliar.IDCategoria = this.accesoDatos.getLector["IDECATEGORIA"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDECATEGORIA"];
                    auxiliar.Nombre = this.accesoDatos.getLector["NOMBRE"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["NOMBRE"];
                    auxiliar.Descripcion = this.accesoDatos.getLector["DESCRIPCION"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["DESCRIPCION"];

                    this.listaCat.Add(auxiliar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.accesoDatos.CerrarConexion();
            }

            return this.listaCat;
        }

        public Categoria ObtenerCategoria(int IDCategoria = 0, string Nombre = "")
        {
            Categoria auxiliar = new Categoria();

            if (IDCategoria == 0)
            {
                if (Nombre != string.Empty || Nombre != null || Nombre != "")
                {
                    auxiliar = this.ObtenerCategorias().Find(x => x.Nombre == Nombre);

                    return auxiliar;
                }
                else
                {
                    return new Categoria();
                }
            }
            else if (IDCategoria > 0)
            {
                auxiliar = ObtenerCategorias().Find(x => x.IDCategoria == IDCategoria);

                return auxiliar;
            }
            else
            {
                return new Categoria();
            }
        }
    }
}
}