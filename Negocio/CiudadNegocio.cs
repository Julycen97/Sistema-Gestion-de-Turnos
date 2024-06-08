using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class CiudadNegocio
    {
        private List<Ciudad> listaCiudades;
        private AccesoDatos accesoDatos;

        private const string select = "SELECT IDCIUDAD, IDPROVINCIA, NOMBRE FROM CIUDADES";
        public CiudadNegocio()
        {
            this.listaCiudades = new List<Ciudad>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Ciudad> ObtenerCiudades()
        {
            try
            {
                this.accesoDatos.SetearComando(select);
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (accesoDatos.getLector.Read())
                {
                    Ciudad auxiliar = new Ciudad();

                    auxiliar.IDCiudad = this.accesoDatos.getLector["IDCIUDAD"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDCIUDAD"];
                    auxiliar.IDProvincia = this.accesoDatos.getLector["IDPROVINCIA"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDPROVINCIA"];
                    auxiliar.Nombre = this.accesoDatos.getLector["NOMBRE"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["NOMBRE"];

                    this.listaCiudades.Add(auxiliar);
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

            return this.listaCiudades;
        }

        public Ciudad ObtenerCiudad(int IDCiudad = 0, string Nombre = "")
        {
            Ciudad auxiliar = new Ciudad();

            if (IDCiudad == 0)
            {
                if (Nombre != string.Empty || Nombre != null || Nombre != "")
                {
                    auxiliar = this.ObtenerCiudades().Find(x => x.Nombre == Nombre);

                    return auxiliar;
                }
                else
                {
                    return new Ciudad();
                }
            }
            else if (IDCiudad > 0)
            {
                auxiliar = ObtenerCiudades().Find(x => x.IDCiudad == IDCiudad);

                return auxiliar;
            }
            else
            {
                return new Ciudad();
            }
        }
    }
}