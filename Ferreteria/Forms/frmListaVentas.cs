using Ferreteria.Conexion;
using Ferreteria.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ferreteria.Forms
{
    public partial class frmListaVentas : Form
    {
        #region Variables Globales
        utilidades util = new utilidades();
        Imagenes imgz = new Imagenes();
        Estilos estilos = new Estilos();
        private DataTable datosOriginales; // Para guardar los datos sin filtrar
        #endregion

        #region Constructor
        public frmListaVentas()
        {
            InitializeComponent();
        }
        #endregion

        #region Load de la pantalla 
        private void frmListaVentas_Load(object sender, EventArgs e)
        {

            DataTable dtProducto = util.EjecutarSp("sp_ObtenerReporteVentas");
            datosOriginales = dtProducto.Copy();
            ConsultarVentasDetalles(dtProducto);
            estilos.EstilizarDataGridViewPOS(dgVenta);
            estilos.EstilizarDataGridViewPOS(dgDetalles);
        }
        #endregion

        #region Consultar Ventas encabezado
        public void ConsultarVentasDetalles(DataTable dtProducto)
        {
            foreach (DataRow row in dtProducto.Rows)
            {
                // Añadir nueva fila al DataGridView
                int rowIndex = dgVenta.Rows.Add();

                // Asignar valores a columnas específicas
                dgVenta.Rows[rowIndex].Cells["colId"].Value = row["VentaId"];
                dgVenta.Rows[rowIndex].Cells["colFecha"].Value = row["Fecha"];
                dgVenta.Rows[rowIndex].Cells["colEmisor"].Value = row["Emisor"];
                dgVenta.Rows[rowIndex].Cells["colReceptor"].Value = row["Receptor"];
                dgVenta.Rows[rowIndex].Cells["colVendedor"].Value = row["Vendedor"];
                dgVenta.Rows[rowIndex].Cells["colTotal"].Value = row["Total"];
                dgVenta.Rows[rowIndex].Cells["colItems"].Value = row["Items"];
                dgVenta.Rows[rowIndex].Cells["colProductos"].Value = row["Productos"];                
            }
        }
        #endregion

        #region Mostrar imagenes
        public void MostrarImagen(byte[] byteImg)
        {
            Image imagen = imgz.ByteArrayToImage(byteImg);
            pbProducto.BackgroundImage = imagen;
            pbProducto.BackgroundImageLayout = ImageLayout.Stretch;
        }
        #endregion

        #region Carga de Detalles de venta
        public void CargarDetalle(int idVenta)
        {
            if (idVenta != 0)
            {
                // Crear un diccionario para los parámetros
                Dictionary<string, object> parametros = new Dictionary<string, object>
            {
                { "@VentaId", idVenta }
            };
                // Ejecutar el SP y obtener el DataTable
                DataTable dtDetalles = util.EjecutarSp("sp_ObtenerDetalleVenta", parametros);
                // Limpiar el DataGridView antes de cargar nuevos datos
                dgDetalles.Rows.Clear();
                // Llenar el DataGridView con los detalles de la venta
                foreach (DataRow row in dtDetalles.Rows)
                {
                    int rowIndex = dgDetalles.Rows.Add();
                    dgDetalles.Rows[rowIndex].Cells["colIdD"].Value = row["ProductoId"];
                    dgDetalles.Rows[rowIndex].Cells["colProducto"].Value = row["Producto"];
                    dgDetalles.Rows[rowIndex].Cells["colFotografia"].Value = row["Fotografia"];
                    dgDetalles.Rows[rowIndex].Cells["colCantidad"].Value = row["Cantidad"];
                    dgDetalles.Rows[rowIndex].Cells["colPrecio"].Value = row["PrecioUnitario"];
                    dgDetalles.Rows[rowIndex].Cells["colImporte"].Value = row["Importe"];
                    dgDetalles.Rows[rowIndex].Cells["colDepartamento"].Value = row["Departamento"];
                }
            }
        }
        #endregion

        private void dgVenta_SelectionChanged(object sender, EventArgs e)
        {
            if (dgVenta.SelectedCells.Count > 0)
            {
                // Obtener la primera celda seleccionada (si hay múltiples selecciones)
                DataGridViewCell celdaSeleccionada = dgVenta.SelectedCells[0];

                // Obtener la fila que contiene esa celda
                DataGridViewRow filaSeleccionada = celdaSeleccionada.OwningRow;
                // Obtener el ID de la venta seleccionada
                try
                {
                    int idVenta = Convert.ToInt32(filaSeleccionada.Cells["colId"].Value);
                    CargarDetalle(idVenta);
                }
                catch (ArgumentException ex)
                {
                }

            }
        }

        private void dgDetalles_SelectionChanged(object sender, EventArgs e)
        {

            if (dgDetalles.SelectedCells.Count > 0)
            {
                // Obtener la primera celda seleccionada (si hay múltiples selecciones)
                DataGridViewCell celdaSeleccionada = dgDetalles.SelectedCells[0];

                // Obtener la fila que contiene esa celda
                DataGridViewRow filaSeleccionada = celdaSeleccionada.OwningRow;
                byte[] arreglo = filaSeleccionada.Cells["colFotografia"].Value as byte[];
                if (arreglo != null)
                {
                    MostrarImagen(arreglo);
                }
                
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (datosOriginales == null) return;

            // Guardar las columnas existentes
            var columnasExistentes = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgVenta.Columns)
            {
                columnasExistentes.Add(col);
            }

            string textoBusqueda = txtBuscador.Text.Trim();
            DataView vista = new DataView(datosOriginales)
            {
                RowFilter = string.IsNullOrWhiteSpace(textoBusqueda)
                    ? string.Empty
                    : GenerarFiltroGlobal(textoBusqueda)
            };

            // Asignar el DataSource
            dgVenta.DataSource = vista;

            // Restaurar las columnas
            dgVenta.Columns.Clear();
            foreach (var col in columnasExistentes)
            {
                dgVenta.Columns.Add(col);
            }
        }
        private string GenerarFiltroGlobal(string textoBusqueda)
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
