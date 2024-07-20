using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysProvincia
    {
        private const string Select = "SELECT IDPROVINCIA, NOMBRE, FROM PROVINCIAS";

        public string getSelect() {  return Select; }
    }
}