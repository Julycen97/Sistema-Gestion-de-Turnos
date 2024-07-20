using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysEspecialidad
    {
        private const string Select = "SELECT IDESPECIALIDAD, NOMBRE, RAMA FROM ESPECIALIDADES";
        private const string Insert = "INSERT INTO ESPECIALIDADES (NOMBRE, RAMA) VALUES (@NOMBRE, @RAMA)";
        private const string Update = "UPDATE ESPECIALIDADES SET NOMBRE = @NOMBRE, RAMA = @RAMA WHERE IDESPECIALIDAD = @IDESPECIALIDAD";
        private const string Delete = "DELETE ESPECIALIDADES WHERE IDESPECIALIDAD = @IDESPECIALIDAD";

        public string getSelect() {  return Select; }
        public string getInsert() {  return Insert; }
        public string getUpdate() {  return Update; }
        public string getDelete() {  return Delete; }
    }
}