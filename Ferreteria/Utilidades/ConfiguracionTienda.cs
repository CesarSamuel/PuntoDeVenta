using System;
using System.IO;
using System.Text.Json;

namespace Ferreteria.Utilidades
{
    public class ConfiguracionTienda
    {
        // Variables públicas para acceso
        public string NombreTienda { get; set; }
        public string Direccion { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string Mensaje { get; set; }
        public ConfiguracionImpresora Impresora { get; set; }

        public class ConfiguracionImpresora
        {
            public string Puerto { get; set; }
            public int BaudRate { get; set; }
            public int AnchoTicket { get; set; }
        }

        // Método para cargar la configuración
        public static ConfiguracionTienda CargarConfiguracion(string rutaArchivo = "configTienda.json")
        {
            try
            {
                string jsonString = File.ReadAllText(rutaArchivo);
                return JsonSerializer.Deserialize<ConfiguracionTienda>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar configuración: {ex.Message}");
                return CrearConfiguracionPorDefecto();
            }
        }

        // Configuración por defecto si no existe el archivo
        private static ConfiguracionTienda CrearConfiguracionPorDefecto()
        {
            return new ConfiguracionTienda
            {
                NombreTienda = "TIENDA POR DEFECTO",
                Direccion = "DIRECCIÓN NO CONFIGURADA",
                RFC = "XAXX010101000",
                Telefono = "000-000-0000",
                Mensaje = "Gracias por su compra",
                Impresora = new ConfiguracionImpresora
                {
                    Puerto = "COM3",
                    BaudRate = 9600,
                    AnchoTicket = 42
                }
            };
        }
    }
}
