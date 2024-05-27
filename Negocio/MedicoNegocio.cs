using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class MedicoNegocio
    {
        private List<Medico> listaMedicos;
        private AccesoDatos accesoDatos;

        public MedicoNegocio() 
        {
            this.listaMedicos = new List<Medico>();
            this.accesoDatos = new AccesoDatos();
        }

        public List<Medico> ObtenerMedicos()
        {
            return this.listaMedicos;
        }

        public Medico ObtenerMedico(int Matricula)
        {
            Medico medico = new Medico();

            return medico;
        }

        private bool VerificarMedico(int Matricula)
        {
            return false;
        }

        public bool AgregarMedico(Medico medico)
        {
            return false;
        }

        public bool ModificarMedico(Medico medico)
        {
            return false;
        }

        public bool EliminarMedico(Medico medico)
        {
            return false;
        }
    }
}