using Dominio;
using Negocio.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class MedicoNegocio
    {
        private QuerysMedico query;
        private List<Medico> listaMedicos;
        private AccesoDatos accesoDatos;

        public MedicoNegocio() 
        {
            this.query = new QuerysMedico();
            this.listaMedicos = new List<Medico>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Medico> ObtenerMedicos()
        {
            PersonaNegocio perNeg = new PersonaNegocio();
            EspecialidadNegocio espNeg = new EspecialidadNegocio();

            try
            {
                this.accesoDatos.SetearComando(query.getSelect());
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (this.accesoDatos.getLector.Read())
                {
                    Persona cargaDatos = new Persona();
                    Medico auxiliar = new Medico();

                    auxiliar.Area = this.accesoDatos.getLector["IDESPECIALIDAD"] is DBNull ? new Especialidad() : espNeg.ObtenerEspecialidad((int)this.accesoDatos.getLector["IDESPECIALIDAD"]);
                    cargaDatos = this.accesoDatos.getLector["DNIPERSONA"] is DBNull ? new Persona() : perNeg.ObtenerPersona((int)this.accesoDatos.getLector["DNIPERSONA"]);
                    
                    auxiliar.NumMatricula = this.accesoDatos.getLector["NUMMATRICULA"] is DBNull ? 0: (int)this.accesoDatos.getLector["NUMMATRICULA"];
                    auxiliar.Estado = (bool)this.accesoDatos.getLector["ESTADO"];


                    auxiliar.Nombre = cargaDatos.Nombre;
                    auxiliar.Apellido = cargaDatos.Apellido;
                    auxiliar.DNI = cargaDatos.DNI;
                    auxiliar.Direccion = cargaDatos.Direccion;
                    auxiliar.Sexo = cargaDatos.Sexo;
                    auxiliar.FechaNacimiento = cargaDatos.FechaNacimiento;

                    this.listaMedicos.Add(auxiliar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return this.listaMedicos;
        }

        public Medico ObtenerMedico(int Matricula)
        {
            Medico auxiliar = new Medico();

            if (VerificarMedico(Matricula))
            {
                return this.ObtenerMedicos().Find(X => X.NumMatricula == Matricula);
            }

            return auxiliar;
        }

        private bool VerificarMedico(int Matricula)
        {
            foreach (Medico X in this.ObtenerMedicos())
            {
                if (X.NumMatricula == Matricula)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ModificarMedico(Medico medico)
        {
            PersonaNegocio persona = new PersonaNegocio();
            Persona auxiliar = new Persona();

            if (this.VerificarMedico(medico.NumMatricula))
            {
                try
                {
                    auxiliar.Nombre = medico.Nombre;
                    auxiliar.Apellido = medico.Apellido;
                    auxiliar.DNI = medico.DNI;
                    auxiliar.FechaNacimiento = medico.FechaNacimiento;
                    auxiliar.Sexo = medico.Sexo;
                    auxiliar.Direccion = medico.Direccion;

                    persona.ModificarPersona(auxiliar);

                    this.accesoDatos.SetearComando(query.getUpdate());
                    this.accesoDatos.SetearParametro("@IDESPECIALIDAD", medico.Area.IDEspecialidad);
                    this.accesoDatos.SetearParametro("@NUMMATRICULA", medico.NumMatricula);

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

        public bool EliminarMedico(Medico medico)
        {
            PersonaNegocio persona = new PersonaNegocio();
            Persona auxiliar = new Persona();

            if (this.VerificarMedico(medico.NumMatricula))
            {
                try
                {
                    this.accesoDatos.SetearComando(query.getDelete());
                    this.accesoDatos.SetearParametro("@NUMMATRICULA", medico.NumMatricula);

                    this.accesoDatos.AbrirConexionEjecutarAccion();
                    this.accesoDatos.CerrarConexion();

                    auxiliar.Nombre = medico.Nombre;
                    auxiliar.Apellido = medico.Apellido;
                    auxiliar.DNI = medico.DNI;
                    auxiliar.FechaNacimiento = medico.FechaNacimiento;
                    auxiliar.Sexo = medico.Sexo;
                    auxiliar.Direccion = medico.Direccion;

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

        public bool BajaMedico(Medico medico)
        {
            if (this.VerificarMedico(medico.NumMatricula))
            {
                try
                {
                    this.accesoDatos.SetearComando(query.getSetStatus());
                    this.accesoDatos.SetearParametro("@NUMMATRICULA", medico.NumMatricula);

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

        public bool AgregarMedico(Medico medico)
        {
            PersonaNegocio persona = new PersonaNegocio();
            Persona auxiliar = new Persona();

            try
            {
                auxiliar.Nombre = medico.Nombre;
                auxiliar.Apellido = medico.Apellido;
                auxiliar.DNI = medico.DNI;
                auxiliar.FechaNacimiento = medico.FechaNacimiento;
                auxiliar.Sexo = medico.Sexo;
                auxiliar.Direccion = medico.Direccion;

                persona.AgregarPersona(auxiliar);

                this.accesoDatos.SetearComando(query.getInsert());
                this.accesoDatos.SetearParametro("@NUMMATRICULA", medico.NumMatricula);
                this.accesoDatos.SetearParametro("@DNIPERSONA", auxiliar.DNI);
                this.accesoDatos.SetearParametro("@IDESPECIALIDAD", medico.Area.IDEspecialidad);
                this.accesoDatos.SetearParametro("@ESTADO", 1);

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