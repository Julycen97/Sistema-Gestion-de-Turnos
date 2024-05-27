using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlDataReader Lector;
        private SqlCommand Comando;
        private SqlConnection Conexion;

        public AccesoDatos()
        {
            this.Conexion = new SqlConnection();
            this.Comando = new SqlCommand();

            this.Comando.CommandType = System.Data.CommandType.Text;
            this.Conexion.ConnectionString = "server= .\\SQLEXPRESS; database= Gestor-de-Turnos-DB; integrated security= true";
        }

        public SqlDataReader getLector
        {
            get { return Lector; }
        }

        public void SetearComando(string Comando)
        {
            this.Comando.CommandText = Comando;
        }

        public void SetearParametro(string Parametro, object Valor)
        {
            this.Comando.Parameters.AddWithValue(Parametro, Valor);
        }

        public SqlDataReader AbrirConexionEjecutarConsulta()
        {
            try
            {
                this.Comando.Connection = this.Conexion;
                this.Conexion.Open();

                Lector = this.Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Lector;
        }

        public void AbrirConexionEjecutarAccion()
        {
            try
            {
                this.Comando.Connection = this.Conexion;
                this.Conexion.Open();

                this.Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            if (Lector != null)
            {
                Lector.Close();
            }

            Conexion.Close();
        }
    }
}