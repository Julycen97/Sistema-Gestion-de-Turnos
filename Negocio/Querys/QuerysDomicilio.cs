using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysDomicilio
    {
        private const string Select = "SELECT IDDOMICILIO, CALLE, ALTURA, IDCIUDAD, CODPOSTAL FROM DOMICILIOS";
        private const string Update = "UPDATE DOMICILIOS SET CALLE = @CALLE, ALTURA = @ALTURA, IDCIUDAD = @IDCIUDAD, CODPOSTAL = @CODPOSTAL WHERE IDDOMICILIO = @IDDOMICILIO";
        private const string Delete = "DELETE DOMICILIO WHERE IDDOMICILIO = @IDDOMICILIO";
        private const string Insert = "INSERT INTO DOMICILIOS (CALLE, ALTURA, IDCIUDAD, CODPOSTAL) VALUES (@CALLE, @ALTURA, @IDCIUDAD, @CODPOSTAL)";

        public string getSelect() {  return Select; }
        public string getUpdate() {  return Update; }
        public string getDelete() {  return Delete; }
        public string getInsert() {  return Insert; }
    }
}