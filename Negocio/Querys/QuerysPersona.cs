using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysPersona
    {
        private const string Select = "SELECT DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO FROM PERSONAS";
        private const string Update = "UPDATE PERSONAS SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, SEXO = @SEXO, FECHANACIMIENTO = @FECHANACIMIENTO WHERE DNI = @DNI";
        private const string Insert = "INSERT INTO PERSONAS (DNI, NOMBRE, APELLIDO, SEXO, FECHANACIMIENTO, IDDOMICILIO) VALUES (@DNI, @NOMBRE, @APELLIDO, @SEXO, @FECHANACIMIENTO, @IDDOMICILIO)";
        private const string Delete = "DELETE PERSONA WHERE DNI = @DNI";

        public string getSelect() {  return Select; }
        public string getUpdate() {  return Update; }
        public string getInsert() {  return Insert; }
        public string getDelete() {  return Delete; }
    }
}