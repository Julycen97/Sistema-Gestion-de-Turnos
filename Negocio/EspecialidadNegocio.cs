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
        public EspecialidadNegocio()
        {
            this.listaEspecial = new List<Especialidad>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            try
            {
                this.accesoDatos.SetearComando("SELECT IDESPECIALIDAD, NOMBRE, RAMA FROM ESPECIALIDADES");
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
    }
}