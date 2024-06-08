using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class CoberturaNegocio
    {
        private AccesoDatos accesoDatos;
        private List<Cobertura> listaCoberturas;
        private const string select = "SELECT IDCOBERTURA, NOMBRE FROM COBERTURAS";
        private const string insert = "INSERT INTO COBERTURAS (NOMBRE) VALUES (@NOMBRE)";
        private const string delete = "DELETE FROM COBERTURAS WHERE IDCOBERTURA = @IDCOBERTURA";

        public CoberturaNegocio()
        {
            this.accesoDatos = new AccesoDatos();
            this.listaCoberturas = new List<Cobertura>();
        }

        public List<Cobertura> ObtenerCoberturas()
        {
            try
            {
                this.accesoDatos.SetearComando(select);
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (accesoDatos.getLector.Read())
                {
                    Cobertura auxiliar = new Cobertura();

                    auxiliar.IDCobertura = this.accesoDatos.getLector["IDCOBERTURA"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDCOBERTURA"];
                    auxiliar.Nombre = this.accesoDatos.getLector["NOMBRE"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["NOMBRE"];

                    this.listaCoberturas.Add(auxiliar);
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

            return this.listaCoberturas;
        }

        public Cobertura ObtenerCobertura(int IDCobertura = 0, string Nombre = "")
        {
            Cobertura auxiliar = new Cobertura();

            if (IDCobertura == 0)
            {
                if (Nombre != string.Empty || Nombre != null || Nombre != "")
                {
                    auxiliar = this.ObtenerCoberturas().Find(x => x.Nombre == Nombre);

                    return auxiliar;
                }
                else
                {
                    return new Cobertura();
                }
            }
            else if (IDCobertura > 0)
            {
                auxiliar = ObtenerCoberturas().Find(x => x.IDCobertura == IDCobertura);

                return auxiliar;
            }
            else
            {
                return new Cobertura();
            }
        }

        public bool AgregarCobertura(string Nombre)
        {
            try
            {
                this.accesoDatos.SetearComando(insert);
                this.accesoDatos.SetearParametro("@NOMBRE", Nombre);

                this.accesoDatos.AbrirConexionEjecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.accesoDatos.CerrarConexion();
            }
        }

        public bool EliminarCobertura(int IDCobertura)
        {
            try
            {
                this.accesoDatos.SetearComando(delete);
                this.accesoDatos.SetearParametro("@IDCOBERTURA", IDCobertura);

                this.accesoDatos.AbrirConexionEjecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.accesoDatos.CerrarConexion();
            }
        }
    }
}