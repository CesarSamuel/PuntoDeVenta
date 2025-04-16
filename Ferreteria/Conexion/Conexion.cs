
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Ferreteria.Conexion
{
    public class Conexion
    {

        public string connectionString { get; }

        public Conexion()
        {
            // Leer el archivo JSON
            string json = File.ReadAllText("appsettings.json");

            // Deserializar el JSON
            JsonDocument document = JsonDocument.Parse(json);
            JsonElement root = document.RootElement;

            // Obtener la cadena de conexión
            connectionString = root.GetProperty("ConnectionStrings")
                                 .GetProperty("FerreteriaConnection")
                                 .GetString();

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Cadena de conexión no encontrada o inválida");
            }
        }

        // Método para ejecutar consultas que no retornan datos (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            int affectedRows = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    affectedRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejo de errores (puedes personalizar esto)
                    Console.WriteLine($"Error al ejecutar consulta: {ex.Message}");
                    throw;
                }
            }

            return affectedRows;
        }

        // Método para ejecutar consultas que retornan datos (SELECT)
        public DataTable ExecuteQuery(string sql, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar consulta: {ex.Message}");
                    throw;
                }
            }

            return dataTable;
        }

        // Método para probar la conexión
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return (connection.State == ConnectionState.Open);
                }
            }
            catch
            {
                return false;
            }
        }
    }
    

}
