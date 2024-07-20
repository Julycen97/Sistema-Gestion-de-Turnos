using Dominio;
using Negocio.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class TurnoNegocio
    {
        private QuerysTurno query;
        private List<Turno> listaTurnos;
        private AccesoDatos accesoDatos;

        public TurnoNegocio()
        {
            this.query = new QuerysTurno();
            this.listaTurnos = new List<Turno>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Turno> ObtenerTurnos()
        {
            try
            {
                this.accesoDatos.SetearComando(query.getSelect());
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (this.accesoDatos.getLector.Read())
                {
                    Turno auxiliar = new Turno();
                    PacienteNegocio paciente = new PacienteNegocio();
                    EspecialidadNegocio especialidad = new EspecialidadNegocio();
                    MedicoNegocio medico = new MedicoNegocio();
                    CategoriaNegocio categoria = new CategoriaNegocio();

                    auxiliar.Datos = this.accesoDatos.getLector["NUMPACIENTE"] is DBNull ? new Paciente() : paciente.ObtenerPaciente((int)this.accesoDatos.getLector["NUMPACIENTE"]);
                    auxiliar.Especial = this.accesoDatos.getLector["IDESPECIALIDAD"] is DBNull ? new Especialidad() : especialidad.ObtenerEspecialidad((int)this.accesoDatos.getLector["IDESPECIALIDAD"]);
                    auxiliar.Doctor = this.accesoDatos.getLector["MATRICULAMEDICO"] is DBNull ? new Medico() : medico.ObtenerMedico((int)this.accesoDatos.getLector["MATRICULAMEDICO"]);
                    auxiliar.CatTurno = this.accesoDatos.getLector["IDCATTURNO"] is DBNull ? new Categoria() : categoria.ObtenerCategoria((int)this.accesoDatos.getLector["IDCATTURNO"]);

                    auxiliar.IDTurno = this.accesoDatos.getLector["IDTURNO"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDTURNO"];
                    auxiliar.FechaHoraTurno = this.accesoDatos.getLector["FECHAHORATURNO"] is DBNull ? new DateTime(1, 1, 1900) : (DateTime)this.accesoDatos.getLector["FECHAHORATURNO"];

                    this.listaTurnos.Add(auxiliar);
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

            return this.listaTurnos;
        }

        public Turno ObtenerTurno(int IDTurno)
        {
            Turno auxiliar = new Turno();

            if (this.VerificarTurno(IDTurno))
            {
                auxiliar = this.ObtenerTurnos().Find(X => X.IDTurno == IDTurno);
            }

            return auxiliar;
        }

        private bool VerificarTurno(int IDTurno)
        {
            foreach (var turno in this.ObtenerTurnos())
            {
                if (turno.IDTurno == IDTurno)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ModificarTurno(Turno turno)
        {
            if (this.VerificarTurno(turno.IDTurno))
            {
                try
                {
                    this.accesoDatos.SetearComando(query.getUpdate());
                    this.accesoDatos.SetearParametro("@MATRICULAMEDICO", turno.Doctor.NumMatricula);
                    this.accesoDatos.SetearParametro("@IDCATTURNO", turno.CatTurno.IDCategoria);
                    this.accesoDatos.SetearParametro("@FECHAHORATURNO", turno.FechaHoraTurno);
                    this.accesoDatos.SetearParametro("@IDTURNO", turno.IDTurno);

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

        public bool EliminarTurno(Turno turno)
        {
            if (this.VerificarTurno(turno.IDTurno))
            {
                try
                {
                    this.accesoDatos.SetearComando(query.getDelete());
                    this.accesoDatos.SetearParametro("@IDTURNO", turno.IDTurno);

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

        public bool AgregarTurno(Turno turno)
        {
            try
            {
                this.accesoDatos.SetearComando(query.getInsert());
                this.accesoDatos.SetearParametro("@NUMPACIENTE", turno.Datos.NumPaciente);
                this.accesoDatos.SetearParametro("@MATRICULAMEDICO", turno.Doctor.NumMatricula);
                this.accesoDatos.SetearParametro("@IDCATTURNO", turno.CatTurno.IDCategoria);
                this.accesoDatos.SetearParametro("@IDESPECIALIDAD", turno.Especial.IDEspecialidad);
                this.accesoDatos.SetearParametro("@FECHAHORATURNO", turno.FechaHoraTurno);

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