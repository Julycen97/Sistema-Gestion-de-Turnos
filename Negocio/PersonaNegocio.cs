using Dominio;
using Negocio.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class PersonaNegocio
    {
        QuerysPersona query;
        private List<Persona> listaPersonas;
        private AccesoDatos accesoDatos;


        public PersonaNegocio()
        {
            this.query = new QuerysPersona();
            this.listaPersonas = new List<Persona>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Persona> ObtenerPersonas()
        {
            try
            {
                this.accesoDatos.SetearComando(query.getSelect());
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (accesoDatos.getLector.Read())
                {
                    Persona auxiliar = new Persona();
                    DomicilioNegocio auxDomiNeg = new DomicilioNegocio();

                    auxiliar.Direccion = this.accesoDatos.getLector["IDDOMICILIO"] is DBNull ? new Domicilio() : auxDomiNeg.ObtenerDomicilio((int)this.accesoDatos.getLector["IDDOMICILIO"]);

                    auxiliar.DNI = this.accesoDatos.getLector["DNI"] is DBNull ? 0 : (int)this.accesoDatos.getLector["DNI"];
                    auxiliar.Nombre = this.accesoDatos.getLector["NOMBRE"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["NOMBRE"];
                    auxiliar.Apellido = this.accesoDatos.getLector["APELLIDO"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["APELLIDO"];
                    auxiliar.Sexo = this.accesoDatos.getLector["SEXO"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["SEXO"];
                    auxiliar.FechaNacimiento = this.accesoDatos.getLector["FECHANACIMIENTO"] is DBNull ? new DateTime(1,1,1900) : (DateTime)this.accesoDatos.getLector["FECHANACIMIENTO"];

                    this.listaPersonas.Add(auxiliar);
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

            return this.listaPersonas;
        }

        public Persona ObtenerPersona(int DNI)
        {
            Persona auxiliar = new Persona();

            if (this.VerificarPersona(DNI))
            {
                auxiliar = this.ObtenerPersonas().Find(x => x.DNI == DNI);
            }

            return auxiliar;
        }

        private bool VerificarPersona(int DNI)
        {
            foreach (Persona X in this.ObtenerPersonas())
            {
                if (X.DNI== DNI)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ModificarPersona(Persona persona)
        {
            DomicilioNegocio domi = new DomicilioNegocio();

            if (this.VerificarPersona(persona.DNI))
            {
                try
                {
                    domi.ModificarDomicilio(persona.Direccion);

                    this.accesoDatos.SetearComando(query.getUpdate());
                    this.accesoDatos.SetearParametro("@NOMBRE", persona.Nombre);
                    this.accesoDatos.SetearParametro("@APELLIDO", persona.Apellido);
                    this.accesoDatos.SetearParametro("@SEX", persona.Sexo);
                    this.accesoDatos.SetearParametro("@FECHANACIMIENTO", persona.FechaNacimiento);
                    this.accesoDatos.SetearParametro("@DNI", persona.DNI);

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
        
        public bool AgregarPersona(Persona persona)
        {
            DomicilioNegocio domi = new DomicilioNegocio();

            try
            {
                domi.AgregarDomicilio(persona.Direccion);

                this.accesoDatos.SetearComando(query.getInsert());

                this.accesoDatos.SetearParametro("@NOMBRE", persona.Nombre);
                this.accesoDatos.SetearParametro("@APELLIDO", persona.Apellido);
                this.accesoDatos.SetearParametro("@DNI", persona.DNI);
                this.accesoDatos.SetearParametro("@SEXO", persona.Sexo);
                this.accesoDatos.SetearParametro("@FECHANAC", persona.FechaNacimiento);
                this.accesoDatos.SetearParametro("@IDDOMICILIO", persona.Direccion.IDDomicilio);

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

        public bool EliminarPersona(Persona persona)
        {
            DomicilioNegocio domi = new DomicilioNegocio();

            try
            {
                this.accesoDatos.SetearComando(query.getDelete());
                this.accesoDatos.SetearParametro("@DNI", persona.DNI);

                this.accesoDatos.AbrirConexionEjecutarAccion();
                this.accesoDatos.CerrarConexion();

                domi.EliminarDomicilio(persona.Direccion.IDDomicilio);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
