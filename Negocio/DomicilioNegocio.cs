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

        public DomicilioNegocio()
        {
            this.listaDomicilios = new List<Domicilio>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Domicilio> ObtenerDomicilios()
        {
            try
            {
                this.accesoDatos.SetearComando("SELECT IDDOMICILIO, CALLE, ALTURA, CIUDAD, PROVINCIA, CODPOSTAL FROM DOMICILIOS");
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (this.accesoDatos.getLector.Read())
                {
                    Domicilio auxiliar = new Domicilio();

                    auxiliar.IDDomicilio = this.accesoDatos.getLector["IDDOMICILIO"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDDOMICILIO"];
                    auxiliar.Calle = this.accesoDatos.getLector["CALLE"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["CALLE"];
                    auxiliar.Altura = this.accesoDatos.getLector["ALTURA"] is DBNull ? 0 : (int)this.accesoDatos.getLector["ALTURA"];
                    auxiliar.Ciudad = this.accesoDatos.getLector["CIUDAD"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["CIUDAD"];
                    auxiliar.Provincia = this.accesoDatos.getLector["CIUDAD"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["PROVINCIA"];
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
                    this.accesoDatos.SetearComando("UPDATE DOMICILIOS SET CALLE = @CALLE, ALTURA = @ALT, CIUDAD = @CIU, PROVINCIA = @PROV, CODPOSTAL = @COD WHERE IDDOMICILIO = @IDDOMI");
                    this.accesoDatos.SetearParametro("@CALLE", domicilio.Calle);
                    this.accesoDatos.SetearParametro("@ALT", domicilio.Altura);
                    this.accesoDatos.SetearParametro("@CIU", domicilio.Ciudad);
                    this.accesoDatos.SetearParametro("@PROV", domicilio.Provincia);
                    this.accesoDatos.SetearParametro("@COD", domicilio.CodPostal);
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
                    this.accesoDatos.SetearComando("DELETE DOMICILIO WHERE IDDOMICILIO = @IDDOMICILIO");
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
                this.accesoDatos.SetearComando("INSERT INTO DOMICILIOS (CALLE, ALTURA, CIUDAD, PROVINCIA, CODPOSTAL) VALUES (@CALLE, @ALTURA, @CIUDAD, @PROVINCIA, @CODPOSTAL)");
                this.accesoDatos.SetearParametro("@CALLE", domicilio.Calle);
                this.accesoDatos.SetearParametro("@ALTURA", domicilio.Altura);
                this.accesoDatos.SetearParametro("@CIUDAD", domicilio.Ciudad);
                this.accesoDatos.SetearParametro("@PROVINCIA", domicilio.Provincia);
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