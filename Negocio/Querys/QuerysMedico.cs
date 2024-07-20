using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysMedico
    {
        private const string Select = "SELECT NUMMATRICULA, DNIPERSONA, IDESPECIALIDAD, ESTADO FROM MEDICOS";
        private const string Update = "UPDATE MEDICOS SET IDESPECIALIDAD = @IDESPECIALIDAD WHERE NUMMATRICULA = @NUMMATRICULA";
        private const string SetStatus = "UPDATE MEDICOS SET ESTADO = 0 WHERE NUMMATRICULA = @NUMMATRICULA";
        private const string Delete = "DELETE MEDICOS WHERE NUMMATRICULA = @NUMMATRICULA";
        private const string Insert = "INSERT INTO MEDICOS (NUMMATRICULA, DNIPERSONA, IDESPECIALIDAD, ESTADO) VALUES (@NUMMATRICULA, @DNIPERSONA, @IDESPECIALIDAD, @ESTADO)";

        public string getSelect() {  return Select; }
        public string getUpdate() {  return Update; }
        public string getDelete() {  return Delete; }
        public string getInsert() {  return Insert; }
        public string getSetStatus() {  return SetStatus; }
    }
}