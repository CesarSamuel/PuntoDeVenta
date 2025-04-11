using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Utilidades
{
    public class Filtros
    {
        public string GenerarFiltroGlobal(string textoBusqueda, DataTable datosOriginales)
        {
            StringBuilder filtro = new StringBuilder();
            string textoLimpio = textoBusqueda.Replace("'", "''");
            bool primeraCondicion = true;

            foreach (DataColumn columna in datosOriginales.Columns)
            {
                if (!primeraCondicion)
                    filtro.Append(" OR ");

                // Filtro que funciona para todos los tipos de datos
                filtro.Append($"CONVERT([{columna.ColumnName}], 'System.String') LIKE '%{textoLimpio}%'");

                primeraCondicion = false;
            }

            return filtro.ToString();
        }
    }
}
