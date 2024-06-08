using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class EspecialidadNegocio
    {
        private List<Especialidad> listaEspecial;
        private AccesoDatos accesoDatos;

        private const string select = "SELECT IDESPECIALIDAD, NOMBRE, RAMA FROM ESPECIALIDADES";
        private const string insert = "INSERT INTO ESPECIALIDADES (NOMBRE, RAMA) VALUES (@NOMBRE, @RAMA)";
        private const string update = "UPDATE ESPECIALIDADES SET NOMBRE = @NOMBRE, RAMA = @RAMA WHERE IDESPECIALIDAD = @IDESPECIALIDAD";
        private const string delete = "DELETE ESPECIALIDADES WHERE IDESPECIALIDAD = @IDESPECIALIDAD";

        public EspecialidadNegocio()
        {
            this.listaEspecial = new List<Especialidad>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            try
            {
                this.accesoDatos.SetearComando(select);
                this.accesoDatos.AbrirConexionEjecutarConsulta();

                while (accesoDatos.getLector.Read())
                {
                    Especialidad auxiliar = new Especialidad();

                    auxiliar.IDEspecialidad = this.accesoDatos.getLector["IDESPECIALIDAD"] is DBNull ? 0 : (int)this.accesoDatos.getLector["IDESPECIALIDAD"];
                    auxiliar.Nombre = this.accesoDatos.getLector["NOMBRE"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["NOMBRE"] ;
                    auxiliar.Rama = this.accesoDatos.getLector["RAMA"] is DBNull ? string.Empty : (string)this.accesoDatos.getLector["RAMA"];

                    this.listaEspecial.Add(auxiliar);
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

            return this.listaEspecial;
        }

        public Especialidad ObtenerEspecialidad(int IDEspecialidad = 0, string Nombre = "")
        {
            Especialidad auxiliar = new Especialidad();

            if (IDEspecialidad == 0)
            {
                if (Nombre != string.Empty || Nombre != null || Nombre != "")
                {
                    auxiliar = this.ObtenerEspecialidades().Find(x => x.Nombre == Nombre);

                    return auxiliar;
                }
                else
                {
                    return new Especialidad();
                }
            }
            else if (IDEspecialidad > 0)
            {
                auxiliar = this.ObtenerEspecialidades().Find(x => x.IDEspecialidad == IDEspecialidad);

                return auxiliar;
            }
            else
            {
                return new Especialidad();
            }
        }

        public bool AgregarEspecialidad(Especialidad especialidad)
        {
            try
            {
                this.accesoDatos.SetearComando(insert);
                this.accesoDatos.SetearParametro("@NOMBRE", especialidad.Nombre);
                this.accesoDatos.SetearParametro("@RAMA", especialidad.Rama);

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

        public bool EliminarEspecialidad(int IDEspecialidad)
        {
            try
            {
                this.accesoDatos.SetearComando(delete);
                this.accesoDatos.SetearParametro("@IDESPECIALIDAD", IDEspecialidad);

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