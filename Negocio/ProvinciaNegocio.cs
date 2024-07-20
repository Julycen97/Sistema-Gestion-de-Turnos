using Dominio;
using Negocio.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class ProvinciaNegocio
    {
        private QuerysProvincia query;
        private List<Provincia> listaProvincias;
        private AccesoDatos accesoDatos;

        public ProvinciaNegocio()
        {
            this.query = new QuerysProvincia();
            this.listaProvincias = new List<Provincia>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Provincia> ObtenerProvincias()
        {
            try
            {
                this.accesoDatos.SetearComando(query.getSelect());
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (accesoDatos.getLector.Read())
                {
                    Provincia auxiliar = new Provincia();

                    auxiliar.IDProvincia = this.accesoDatos.getLector["IDPROVINCIA"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDPROVINCIA"];
                    auxiliar.Nombre = this.accesoDatos.getLector["NOMBRE"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["NOMBRE"];

                    this.listaProvincias.Add(auxiliar);
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

            return this.listaProvincias;
        }

        public Provincia ObtenerProvincia(int IDProvincia = 0, string Nombre = "")
        {
            Provincia auxiliar = new Provincia();

            if (IDProvincia == 0)
            {
                if (Nombre != string.Empty || Nombre != null || Nombre != "")
                {
                    auxiliar = this.ObtenerProvincias().Find(x => x.Nombre == Nombre);

                    return auxiliar;
                }
                else
                {
                    return new Provincia();
                }
            }
            else if (IDProvincia > 0)
            {
                auxiliar = ObtenerProvincias().Find(x => x.IDProvincia == IDProvincia);

                return auxiliar;
            }
            else
            {
                return new Provincia();
            }
        }
    }
}