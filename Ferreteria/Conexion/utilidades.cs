using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Conexion
{
    public class utilidades
    {
        Conexion db = new Conexion();

        #region Ejecucion de SP
        public DataTable EjecutarSp(string nombreSP, Dictionary<string, object> parametros = null)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection conexion = new SqlConnection(db.connectionString))
            {
                using (SqlCommand comando = new SqlCommand(nombreSP, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros si existen
                    if (parametros != null)
                    {
                        foreach (var parametro in parametros)
                        {
                            comando.Parameters.AddWithValue(parametro.Key, parametro.Value ?? DBNull.Value);
                        }
                    }

                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        resultado.Load(reader); // Cargar los datos directamente al DataTable
                    }
                }
            }

            return resultado;
        }
        #endregion

    }
}
