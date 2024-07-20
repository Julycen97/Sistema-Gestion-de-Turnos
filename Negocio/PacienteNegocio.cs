using Dominio;
using Negocio.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.ApplicationServices;

namespace Negocio
{
    public class PacienteNegocio
    {
        private QuerysPaciente query;
        private List<Paciente> listaPacientes;
        private AccesoDatos accesoDatos;

        public PacienteNegocio()
        {
            this.query = new QuerysPaciente();
            this.listaPacientes = new List<Paciente>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Paciente> ObtenerPacientes()
        {
            PersonaNegocio persona = new PersonaNegocio();
            CoberturaNegocio cobertura = new CoberturaNegocio();

            try
            {
                this.accesoDatos.SetearComando(this.query.getSelect());

                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (this.accesoDatos.getLector.Read())
                {
                    Paciente auxiliar = new Paciente();
                    Persona cargaDatos = new Persona();

                    cargaDatos = this.accesoDatos.getLector["DNIPERSONA"] is DBNull ? new Persona() : persona.ObtenerPersona((int)this.accesoDatos.getLector["DNIPERSONA"]);
                    auxiliar.Cobertura = this.accesoDatos.getLector["IDCOBERTURA"] is DBNull ? new Cobertura() : cobertura.ObtenerCobertura((int)this.accesoDatos.getLector["IDCOBERTURA"]);

                    auxiliar.NumPaciente = this.accesoDatos.getLector["NUMPACIENTE"] is DBNull ? 0 : (int)this.accesoDatos.getLector["NUMPACIENTE"];
                    auxiliar.FechaAfiliacion = this.accesoDatos.getLector["FECHAAFILIACION"] is DBNull ? new DateTime(1, 1, 1900) : (DateTime)this.accesoDatos.getLector["FECHAAFILIACION"];

                    auxiliar.Nombre = cargaDatos.Nombre;
                    auxiliar.Apellido = cargaDatos.Apellido;
                    auxiliar.DNI = cargaDatos.DNI;
                    auxiliar.Direccion = cargaDatos.Direccion;
                    auxiliar.Sexo = cargaDatos.Sexo;
                    auxiliar.FechaNacimiento = cargaDatos.FechaNacimiento;

                    this.listaPacientes.Add(auxiliar);
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

            return this.listaPacientes;
        }

        public Paciente ObtenerPaciente(int NumPaciente)
        {
            Paciente auxiliar = new Paciente();

            if (this.VerificarPaciente(NumPaciente))
            {
                auxiliar = this.ObtenerPacientes().Find(X => X.NumPaciente == NumPaciente);
            }

            return auxiliar;
        }

        private bool VerificarPaciente(int NumPaciente)
        {
            foreach (Paciente X in this.ObtenerPacientes())
            {
                if (X.NumPaciente == NumPaciente)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ModificarPaciente(Paciente paciente)
        {
            PersonaNegocio persona = new PersonaNegocio();
            Persona auxiliar = new Persona();

            if (this.VerificarPaciente(paciente.NumPaciente))
            {
                try
                {
                    auxiliar.Nombre = paciente.Nombre;
                    auxiliar.Apellido = paciente.Apellido;
                    auxiliar.DNI = paciente.DNI;
                    auxiliar.FechaNacimiento = paciente.FechaNacimiento;
                    auxiliar.Sexo = paciente.Sexo;
                    auxiliar.Direccion = paciente.Direccion;

                    persona.ModificarPersona(auxiliar);

                    this.accesoDatos.SetearComando(this.query.getUpdate());
                    this.accesoDatos.SetearParametro("@FECHAAFILIACION", paciente.FechaAfiliacion);
                    this.accesoDatos.SetearParametro("@IDCOBERTURA", paciente.Cobertura.IDCobertura);
                    this.accesoDatos.SetearParametro("@NUMPACIENTE", paciente.NumPaciente);

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

        public bool EliminarPaciente(Paciente paciente)
        {
            PersonaNegocio persona = new PersonaNegocio();
            Persona auxiliar = new Persona();

            if (this.VerificarPaciente(paciente.NumPaciente))
            {
                try
                {
                    this.accesoDatos.SetearComando(this.query.getDelete());
                    this.accesoDatos.SetearParametro("@NUMPACIENTE", paciente.NumPaciente);

                    this.accesoDatos.AbrirConexionEjecutarAccion();
                    this.accesoDatos.CerrarConexion();

                    auxiliar.Nombre = paciente.Nombre;
                    auxiliar.Apellido = paciente.Apellido;
                    auxiliar.DNI = paciente.DNI;
                    auxiliar.FechaNacimiento = paciente.FechaNacimiento;
                    auxiliar.Sexo = paciente.Sexo;
                    auxiliar.Direccion = paciente.Direccion;

                    persona.EliminarPersona(auxiliar);

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return false;
        }

        public bool AgregarPaciente(Paciente paciente)
        {
            PersonaNegocio persona = new PersonaNegocio();
            Persona auxiliar = new Persona();

            try
            {
                auxiliar.Nombre = paciente.Nombre;
                auxiliar.Apellido = paciente.Apellido;
                auxiliar.DNI = paciente.DNI;
                auxiliar.FechaNacimiento = paciente.FechaNacimiento;
                auxiliar.Sexo = paciente.Sexo;
                auxiliar.Direccion = paciente.Direccion;

                persona.AgregarPersona(auxiliar);

                this.accesoDatos.SetearComando(this.query.getInsert());
                this.accesoDatos.SetearParametro("@IDPERSONA", paciente.DNI);
                this.accesoDatos.SetearParametro("@FECHAAFILIACION", paciente.FechaAfiliacion);
                this.accesoDatos.SetearParametro("@IDCOBERTURA", paciente.Cobertura.IDCobertura);

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