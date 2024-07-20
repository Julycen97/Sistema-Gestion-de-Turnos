using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Querys
{
    public class QuerysCategorias
    {
        private const string Select = "SELECT IDCATEGORIA, NOMBRE, DESCRIPCION FROM CATEGORIAS";

        public string getSelect() { return Select; }
    }
}