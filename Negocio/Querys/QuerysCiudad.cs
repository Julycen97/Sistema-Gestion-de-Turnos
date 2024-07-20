using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysCiudad
    {
        private const string Select = "SELECT IDCIUDAD, IDPROVINCIA, NOMBRE FROM CIUDADES";

        public string getSelect() { return Select; }
    }
}