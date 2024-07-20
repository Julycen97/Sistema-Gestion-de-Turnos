using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysPaciente
    {
        private const string Select = "SELECT NUMPACIENTE, DNIPERSONA, FECHAAFILIACION, IDCOBERTURA FROM PACIENTES";
        private const string Update = "UPDATE PACIENTES SET FECHAAFILIACION = @FECHAAFILIACION, IDCOBERTURA = @IDCOBERTURA WHERE NUMPACIENTE = @NUMPACIENTE";
        private const string Delete = "DELETE PACIENTES WHERE NUMPACIENTE = @NUMPACIENTE";
        private const string Insert = "INSERT INTO PACIENTES (DNIPERSONA, FECHAAFILIACION, IDCOBERTURA) VALUES (@DNIPERSONA, @FECHAAFILIACION, @IDCOBERTURA)";

        public string getSelect() {  return Select; }
        public string getUpdate() {  return Update; }
        public string getDelete() {  return Delete; }
        public string getInsert() {  return Insert; }
    }
}