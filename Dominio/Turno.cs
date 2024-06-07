using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace Dominio
{
    public class Turno
    {
        public Turno()
        {
            this.IDTurno = 0;
            this.Datos = new Paciente();
            this.FechaHoraTurno = new DateTime(1, 1, 1900);
            this.Especial = new Especialidad();
            this.Doctor = new Medico();
            this.CatTurno = new Categoria();
        }

        public Turno(int IDTurno, Paciente Datos, DateTime FechaHoraTurno, Especialidad Especial, Medico Doctor, Categoria CatTurno)
        {
            this.IDTurno = IDTurno;
            this.Datos = Datos;
            this.FechaHoraTurno = FechaHoraTurno;
            this.Especial = Especial;
            this.Doctor = Doctor;
            this.CatTurno = CatTurno;
        }

        [DisplayName ("Numero de Turno")]
        public int IDTurno { get; set; }
        [DisplayName ("Datos Paciente")]
        public Paciente Datos { get; set; }
        [DisplayName ("Fecha y Hora de Turno")]
        public DateTime FechaHoraTurno { get; set; }
        [DisplayName ("Especialidad")]
        public Especialidad Especial { get; set; }
        [DisplayName ("Medico")]
        public Medico Doctor { get; set; }
        [DisplayName ("Categoria del Turno")]
        public Categoria CatTurno { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("        DETALLE DEL TURNO\n");
            retorno.Append("Numero de Turno:        " + this.IDTurno + "\n");
            retorno.Append("   DATOS DEL PACIENTE\n" + this.Datos.ToString());
            retorno.Append("Fecha y Hora del Turno: " + this.FechaHoraTurno.ToString() + "\n");
            retorno.Append(this.Especial.ToString());
            retorno.Append("Medico:                 " + this.Doctor.ToString());
            retorno.Append(this.CatTurno.ToString());

            return retorno.ToString();
        }
    }
}