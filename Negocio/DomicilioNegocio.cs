using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class DomicilioNegocio
    {
        private List<Domicilio> listaDomicilios;
        private AccesoDatos accesoDatos;

        private const string select = "SELECT IDDOMICILIO, CALLE, ALTURA, IDCIUDAD, CODPOSTAL FROM DOMICILIOS";
        private const string update = "UPDATE DOMICILIOS SET CALLE = @CALLE, ALTURA = @ALTURA, IDCIUDAD = @IDCIUDAD, CODPOSTAL = @CODPOSTAL WHERE IDDOMICILIO = @IDDOMICILIO";
        private const string delete = "DELETE DOMICILIO WHERE IDDOMICILIO = @IDDOMICILIO";
        private const string insert = "INSERT INTO DOMICILIOS (CALLE, ALTURA, IDCIUDAD, CODPOSTAL) VALUES (@CALLE, @ALTURA, @IDCIUDAD, @CODPOSTAL)";

        public DomicilioNegocio()
        {
            this.listaDomicilios = new List<Domicilio>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Domicilio> ObtenerDomicilios()
        {
            CiudadNegocio ciudad = new CiudadNegocio();

            try
            {
                this.accesoDatos.SetearComando(select);
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (this.accesoDatos.getLector.Read())
                {
                    Domicilio auxiliar = new Domicilio();

                    auxiliar.Ciudad = this.accesoDatos.getLector["IDCIUDAD"] is DBNull ? new Ciudad() : ciudad.ObtenerCiudad((int)this.accesoDatos.getLector["IDCIUDAD"]);
                    
                    auxiliar.IDDomicilio = this.accesoDatos.getLector["IDDOMICILIO"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDDOMICILIO"];
                    auxiliar.Calle = this.accesoDatos.getLector["CALLE"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["CALLE"];
                    auxiliar.Altura = this.accesoDatos.getLector["ALTURA"] is DBNull ? 0 : (int)this.accesoDatos.getLector["ALTURA"];
                    auxiliar.CodPostal = this.accesoDatos.getLector["CODPOSTAL"] is DBNull ? 0 : (int)this.accesoDatos.getLector["CODPOSTAL"];

                    this.listaDomicilios.Add(auxiliar);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return this.listaDomicilios;
        }

        public Domicilio ObtenerDomicilio(int IDDomicilio)
        {
            Domicilio auxiliar = new Domicilio();

            if (this.VerificarDomicilio(IDDomicilio))
            {
                auxiliar = this.ObtenerDomicilios().Find(x => x.IDDomicilio == IDDomicilio);
            }
            
            return auxiliar;
        }

        private bool VerificarDomicilio(int IDDOmicilio)
        {
            foreach (Domicilio X in this.ObtenerDomicilios())
            {
                if (X.IDDomicilio == IDDOmicilio)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ModificarDomicilio(Domicilio domicilio)
        {
            if (this.VerificarDomicilio(domicilio.IDDomicilio))
            {
                try
                {
                    this.accesoDatos.SetearComando(update);
                    this.accesoDatos.SetearParametro("@CALLE", domicilio.Calle);
                    this.accesoDatos.SetearParametro("@ALTURA", domicilio.Altura);
                    this.accesoDatos.SetearParametro("@IDCIUDAD", domicilio.Ciudad.IDCiudad);
                    this.accesoDatos.SetearParametro("@CODPOSTAL", domicilio.CodPostal);
                    this.accesoDatos.SetearParametro("@IDDOMI", domicilio.IDDomicilio);

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
            else
            {
                return false;
            }
        }

        public bool EliminarDomicilio(int IDDomicilio)
        {
            if (this.VerificarDomicilio(IDDomicilio))
            {
                try
                {
                    this.accesoDatos.SetearComando(delete);
                    this.accesoDatos.SetearParametro("@IDDOMICILIO", IDDomicilio);

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

            return false;
        }

        public bool AgregarDomicilio(Domicilio domicilio)
        {
            try
            {
                this.accesoDatos.SetearComando(insert);
                this.accesoDatos.SetearParametro("@CALLE", domicilio.Calle);
                this.accesoDatos.SetearParametro("@ALTURA", domicilio.Altura);
                this.accesoDatos.SetearParametro("@IDCIUDAD", domicilio.Ciudad.IDCiudad);
                this.accesoDatos.SetearParametro("@CODPOSTAL", domicilio.CodPostal);

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