using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Negocio
{
    public class PacienteNegocio
    {
        private List<Paciente> listaPacientes;
        private AccesoDatos accesoDatos;

        public PacienteNegocio()
        {
            this.listaPacientes = new List<Paciente>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Paciente> ObtenerPacientes()
        {
            PersonaNegocio persona = new PersonaNegocio();

            try
            {
                this.accesoDatos.SetearComando("SELECT NUMPACIENTE, IDPERSONA, FECHAAFILIACION, COBERTURA FROM PACIENTES");

                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (this.accesoDatos.getLector.Read())
                {
                    Paciente auxiliar = new Paciente();
                    Persona cargaDatos = new Persona();

                    cargaDatos = persona.ObtenerPersona((int)this.accesoDatos.getLector["IDPERSONA"]);

                    auxiliar.NumPaciente = this.accesoDatos.getLector["NUMPACIENTE"] is DBNull ? 0 : (int)this.accesoDatos.getLector["NUMPACIENTE"];
                    auxiliar.FechaAfiliacion = this.accesoDatos.getLector["FECHAAFILIACION"] is DBNull ? new DateTime(1, 1, 1900) : (DateTime)this.accesoDatos.getLector["FECHAAFILIACION"];
                    auxiliar.Cobertura = this.accesoDatos.getLector["COBERTURA"] is DBNull ? "No Cobertura" : (string)this.accesoDatos.getLector["COBERTURA"];

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

                    this.accesoDatos.SetearComando("UPDATE PACIENTE SET FECHAAFILIACION = @FECHAAFILIACION, COBERTURA = @COBERTURA WHERE  NUMPACIENTE = @NUMPACIENTE");
                    this.accesoDatos.SetearParametro("@FECHAAFILIACION", paciente.FechaAfiliacion);
                    this.accesoDatos.SetearParametro("@COBERTURA", paciente.Cobertura);
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
                    this.accesoDatos.SetearComando("DELETE PACIENTES WHERE NUMPACIENTE = @NUMPACIENTE");
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

                this.accesoDatos.SetearComando("INSERT INTO PACIENTES (IDPERSONA, FECHAAFILIACION, COBERTURA) VALUES (@IDPERSONA, @FECHAAFILIACION, @COBERTURA)");
                this.accesoDatos.SetearParametro("@IDPERSONA", paciente.DNI);
                this.accesoDatos.SetearParametro("@FECHAAFILIACION", paciente.FechaAfiliacion);
                this.accesoDatos.SetearParametro("@COBERTURA", paciente.Cobertura);

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