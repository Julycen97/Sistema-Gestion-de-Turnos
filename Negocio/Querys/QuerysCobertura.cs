using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysCobertura
    {
        private const string Select = "SELECT IDCOBERTURA, NOMBRE FROM COBERTURAS";
        private const string Insert = "INSERT INTO COBERTURAS (NOMBRE) VALUES (@NOMBRE)";
        private const string Delete = "DELETE FROM COBERTURAS WHERE IDCOBERTURA = @IDCOBERTURA";

        public string getSelect() {  return Select; }
        public string getInsert() {  return Insert; }
        public string getDelete() {  return Delete; }
    }
}