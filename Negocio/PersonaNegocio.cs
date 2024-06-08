using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class PersonaNegocio
    {
        private List<Persona> listaPersonas;
        private AccesoDatos accesoDatos;

        private const string select = "SELECT DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO FROM PERSONAS";
        private const string update = "UPDATE PERSONAS SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, SEXO = @SEXO, FECHANACIMIENTO = @FECHANACIMIENTO WHERE DNI = @DNI";
        private const string insert = "INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO) VALUES (@DNI, @NOMBRE, @APELLIDO, @SEXO, @FECHANACIMIENTO, @IDDOMICILIO)";
        private const string delete = "DELETE PERSONA WHERE DNI = @DNI";

        public PersonaNegocio()
        {
            this.listaPersonas = new List<Persona>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Persona> ObtenerPersonas()
        {
            try
            {
                this.accesoDatos.SetearComando(select);
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (accesoDatos.getLector.Read())
                {
                    Persona auxiliar = new Persona();
                    DomicilioNegocio auxDomiNeg = new DomicilioNegocio();

                    auxiliar.DNI = this.accesoDatos.getLector["DNI"] is DBNull ? 0 : (int)this.accesoDatos.getLector["DNI"];
                    auxiliar.Nombre = this.accesoDatos.getLector["NOMBRE"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["NOMBRE"];
                    auxiliar.Apellido = this.accesoDatos.getLector["APELLIDO"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["APELLIDO"];
                    auxiliar.Sexo = this.accesoDatos.getLector["SEXO"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["SEXO"];
                    auxiliar.FechaNacimiento = this.accesoDatos.getLector["FECHANACIMIENTO"] is DBNull ? new DateTime(1,1,1900) : (DateTime)this.accesoDatos.getLector["FECHANACIMIENTO"];

                    auxiliar.Direccion = auxDomiNeg.ObtenerDomicilio((int)this.accesoDatos.getLector["IDDOMICILIO"]);

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

                    this.accesoDatos.SetearComando(update);
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

                this.accesoDatos.SetearComando(insert);

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
                this.accesoDatos.SetearComando(delete);
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
