using Ferreteria.Conexion;
using Ferreteria.Utilidades;
using System;
using System.Collections;
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
        Filtros filtros = new Filtros();
        public int idCliente;
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
            ValidarFiltros();
        }
        #endregion

        #region Validar Filtros
        public void ValidarFiltros()
        {
            bool activar = !chbUltimosDias.Checked;
            dtpFechaInicio.Enabled = activar;
            dtpFechaFin.Enabled = activar;
            txtRfc.Enabled = activar;
            chbFechas.Enabled = activar;
            if (!activar)
            {
                dtpFechaInicio.Value = DateTime.Now;
                dtpFechaFin.Value = DateTime.Now;
                txtRfc.Text = "";
                txtCliente.Text = "";
                txtEmpleado.Text = "";
                chbFechas.Checked = true;
            }
        }
        #endregion

        #region Busqueda de cliente
        public void BuscarCliente()
        {
            // Crear un diccionario para los parámetros
            var parametros = new Dictionary<string, object>
            {
                    { "@rfc", txtRfc.Text }
                };
            // Ejecutar el procedimiento almacenado
            DataTable resultado = util.EjecutarSp("sp_ConsultarReceptor", parametros);
            if (resultado.Rows.Count != 0)
            {
                // Si se encuentra el cliente, asignar los valores a los controles
                txtCliente.Text = resultado.Rows[0]["RazonSocial"].ToString();
                idCliente = int.Parse(resultado.Rows[0]["Id"].ToString());
            }
            else
            {
                // Si no se encuentra el cliente, limpiar los controles
                MessageBox.Show(
               "Cliente no encontrado, Favor de revisar la información Proporcionada",
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Consultar Ventas encabezado
        public void ConsultarVentasDetalles(DataTable dtProducto)
        {
            dgVenta.DataSource = null;
            if (dgVenta.Columns.Count == 0)
            {
                crearColumnas();
            }
            dgVenta.AutoGenerateColumns = true;
            
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

        #region Crear Columnas
        public void crearColumnas()
        {
            dgVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = "VentaId", // Nombre del campo en el DataSource
                HeaderText = "ID",
                Visible = false, 
                ReadOnly = false
            });
            dgVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                DataPropertyName = "Fecha", // Nombre del campo en el DataSource
                HeaderText = "Fecha",
                Visible = true,
                ReadOnly = false
            });
            dgVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmisor",
                DataPropertyName = "Emisor", // Nombre del campo en el DataSource
                HeaderText = "Emisor",
                Visible = true,
                ReadOnly = false
            });
            dgVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colReceptor",
                DataPropertyName = "Receptor", // Nombre del campo en el DataSource
                HeaderText = "Receptor",
                Visible = true,
                ReadOnly = false
            });
            dgVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVendedor",
                DataPropertyName = "Vendedor", // Nombre del campo en el DataSource
                HeaderText = "Vendedor",
                Visible = true,
                ReadOnly = false
            });
            dgVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                DataPropertyName = "Total", // Nombre del campo en el DataSource
                HeaderText = "Total",
                Visible = true,
                ReadOnly = false
            });
            dgVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colItems",
                DataPropertyName = "Items", // Nombre del campo en el DataSource
                HeaderText = "Total",
                Visible = true,
                ReadOnly = false
            });
            dgVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductos",
                DataPropertyName = "Productos", // Nombre del campo en el DataSource
                HeaderText = "Productos",
                Visible = true,
                ReadOnly = false
            });
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
            Buscador();
        }

        public void Buscador()
        {
            if (datosOriginales == null) return;

            // Guardar las columnas existentes
            var columnasExistentes = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgVenta.Columns)
            {
                columnasExistentes.Add(col);
            }

            string textoBusqueda = txtBuscador.Text.Trim();
            if(textoBusqueda == "")
            {
                dgVenta.DataSource = datosOriginales;
            }
            else
            {
                DataView vista = new DataView(datosOriginales)
                {
                    RowFilter = string.IsNullOrWhiteSpace(textoBusqueda)
                                     ? string.Empty
                                     : filtros.GenerarFiltroGlobal(textoBusqueda, datosOriginales)
                };

                // Asignar el DataSource
                dgVenta.DataSource = vista;

            }

            // Restaurar las columnas
            dgVenta.Columns.Clear();
            foreach (var col in columnasExistentes)
            {
                dgVenta.Columns.Add(col);
            }
        }

        private void chbUltimosDias_CheckedChanged(object sender, EventArgs e)
        {
            ValidarFiltros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscador.Text = "";
            Buscador();
            CondicionesBusqueda();
        }

        public void CondicionesBusqueda()
        {
            int error = 0;
            if (chbUltimosDias.Checked)
            {
                DataTable dtProducto = util.EjecutarSp("sp_ObtenerReporteVentas");
                datosOriginales = dtProducto.Copy();
                ConsultarVentasDetalles(dtProducto);
                ValidarFiltros();
            }
            else
            {
                var parametros = new Dictionary<string, object> { };
                if (txtRfc.Text != "" && idCliente != 0)
                {
                    parametros.Add("@ReceptorId", idCliente);
                }
                if (chbFechas.Checked)
                {
                    parametros.Add("@FechaInicio", dtpFechaInicio.Value);
                    parametros.Add("@FechaFin", dtpFechaFin.Value);
                }
                if (txtEmpleado.Text != "")
                {
                    parametros.Add("@UsuarioId", txtEmpleado.Text);
                }
                if(error == 0)
                {
                    // Ejecutar el procedimiento almacenado
                    DataTable resultado = util.EjecutarSp("sp_ObtenerReporteVentas", parametros);
                    if (resultado.Rows.Count != 0)
                    {
                        // Si se encuentra el cliente, asignar los valores a los controles
                        ConsultarVentasDetalles(resultado);
                    }
                }
                else
                {
                    error = 1;
                    MessageBox.Show(
                   "Falta informacion para poder buscar",
                   "Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void chbFechas_CheckedChanged(object sender, EventArgs e)
        {
            bool activar = chbFechas.Checked;
            dtpFechaInicio.Enabled = activar;
            dtpFechaFin.Enabled = activar;
        }

        private void txtRfc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCliente();
            }
        }
    }
}
