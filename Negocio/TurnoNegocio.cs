using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class TurnoNegocio
    {
        private List<Turno> listaTurnos;
        private AccesoDatos accesoDatos;

        public TurnoNegocio()
        {
            listaTurnos = new List<Turno>();
            accesoDatos = new AccesoDatos();
        }

        public List<Turno> ObtenerTurnos()
        {
            try
            {
                this.accesoDatos.SetearComando("SELECT IDTURNO, NUMPACIENTE, FECHAHORATURNO, IDESPECIALIDAD, MATRICULAMEDICO, IDCATTURNO FROM TURNOS");
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (this.accesoDatos.getLector.Read())
                {
                    Turno auxiliar = new Turno();
                    PacienteNegocio paciente = new PacienteNegocio();
                    EspecialidadNegocio especialidad = new EspecialidadNegocio();
                    MedicoNegocio medico = new MedicoNegocio();
                    CategoriaNegocio categoria = new CategoriaNegocio();

                    auxiliar.IDTurno = this.accesoDatos.getLector["IDTURNO"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDTURNO"];
                    auxiliar.Datos = this.accesoDatos.getLector["IDPACIENTE"] is DBNull ? new Paciente() : paciente.ObtenerPaciente((int)this.accesoDatos.getLector["IDPACIENTE"]);
                    auxiliar.FechaHoraTurno = this.accesoDatos.getLector["FECHAHORATURNO"] is DBNull ? new DateTime(1, 1, 1900) : (DateTime)this.accesoDatos.getLector["FECHAHORATURNO"];
                    auxiliar.Especial = this.accesoDatos.getLector["IDESPECIAL"] is DBNull ? new Especialidad() : especialidad.ObtenerEspecialidad((int)this.accesoDatos.getLector["IDESPECIAL"]);
                    auxiliar.Doctor = this.accesoDatos.getLector["MATRICULAMEDICO"] is DBNull ? new Medico() : medico.ObtenerMedico((int)this.accesoDatos.getLector["MATRICULAMEDICO"]);
                    auxiliar.CatTurno = this.accesoDatos.getLector["IDCATTURNO"] is DBNull ? new Categoria() : categoria.ObtenerCategoria((int)this.accesoDatos.getLector["IDCATTURNO"]);

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
                    this.accesoDatos.SetearComando("UPDATE TURNO SET FECHAHORATURNO = @FECHA, MATRICULAMEDICO = @MATRICULAMEDICO");
                    this.accesoDatos.SetearParametro("@FECHA", turno.FechaHoraTurno);
                    this.accesoDatos.SetearParametro("@MATRICULAMEDICO", turno.Doctor.NumMatricula);

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
                    this.accesoDatos.SetearComando("DELETE TURNO WHERE IDTURNO = @IDTURNO");
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
                this.accesoDatos.SetearComando("INSERT INTO TURNOS (IDPACIENTE, FECHAHORATURNO, IDESPECIALIDAD, MATRICULAMEDICO, IDCATTURNO) VALUES (@IDPACIENTE, @FECHAHORATURNO, @IDESPECIALIDAD, @MATRICULA, @IDCATTURNO)");
                this.accesoDatos.SetearParametro("@IDPACIENTE", turno.Datos.NumPaciente);
                this.accesoDatos.SetearParametro("@FECHAHORATURNO", turno.FechaHoraTurno);
                this.accesoDatos.SetearParametro("@IDESPECIALIDAD", turno.Especial.IDEspecialidad);
                this.accesoDatos.SetearParametro("@MATRICULA", turno.Doctor.NumMatricula);
                this.accesoDatos.SetearParametro("@IDCATTURNO", turno.CatTurno.IDCategoria);

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