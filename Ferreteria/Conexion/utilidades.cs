using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferreteria.Conexion
{
    public class utilidades
    {
        Conexion db = new Conexion();

        #region Ejecucion de SP
        public DataTable EjecutarSp(string nombreSP, Dictionary<string, object> parametros = null)
        {
            DataTable resultado = new DataTable();

            using ( SqlConnection conexion = new SqlConnection(db.connectionString))
            {
                using (SqlCommand comando = new SqlCommand(nombreSP, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros con manejo especial para byte[]
                    if (parametros != null)
                    {
                        foreach (var parametro in parametros)
                        {
                            if (parametro.Value is byte[] bytes)
                            {
                                var param = new SqlParameter(parametro.Key, SqlDbType.VarBinary, -1); // -1 = MAX
                                param.Value = bytes;
                                comando.Parameters.Add(param);
                            }
                            else
                            {
                                comando.Parameters.AddWithValue(parametro.Key, parametro.Value ?? DBNull.Value);
                            }
                        }
                    }

                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        resultado.Load(reader);
                    }
                }
            }

            return resultado;
        }

        #endregion

    }
}
