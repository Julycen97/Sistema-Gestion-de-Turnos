using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysTurno
    {
        private const string Select = "SELECT IDTURNO, NUMPACIENTE, MATRICULAMEDICO, IDCATTURNO, IDESPECIALIDAD, FECHAHORATURNO FROM TURNOS";
        private const string Update = "UPDATE TURNOS SET MATRICULAMEDICO = @MATRICULAMEDICO, IDCATTURNO = @IDCATTURNO, FECHAHORATURNO = @FECHAHORATURNO WHERE IDTURNO = @IDTURNO";
        private const string Delete = "DELETE TURNOS WHERE IDTURNO = @IDTURNO";
        private const string Insert = "INSERT INTO TURNOS (NUMPACIENTE, MATRICULAMEDICO, IDCATTURNO, IDESPECIALIDAD, FECHAHORATURNO) VALUES (@NUMPACIENTE, @MATRICULAMEDICO, @IDCATTURNO, @IDESPECIALIDAD, @FECHAHORATURNO)";

        public string getSelect() {  return Select; }
        public string getUpdate() {  return Update; }
        public string getDelete() {  return Delete; }
        public string getInsert() {  return Insert; }
    }
}