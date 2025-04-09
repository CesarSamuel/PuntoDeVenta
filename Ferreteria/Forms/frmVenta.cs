using Ferreteria.Conexion;
using Ferreteria.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ferreteria.Forms
{
    public partial class frmVenta : Form
    {
        #region Variables Globales
        public int IdUsuario;
        public decimal IVA;
        public bool descuentos, facturacion;
        utilidades util = new utilidades();
        Imagenes imgz = new Imagenes();
        public int idCliente;
        #endregion

        public frmVenta(int idUsuario)
        {
            InitializeComponent();
            this.IdUsuario = idUsuario;
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            AsignarFecha();
            BuscarCliente();
            IVA = decimal.Parse(configuracionesGlobales(1));
            txtIva.Text = IVA.ToString("C2");
            descuentos = Convert.ToBoolean(Convert.ToInt32(configuracionesGlobales(2)));
            if (!descuentos)
            {
                txtDescuentos.Text = "Desactivado";
            }
            facturacion = Convert.ToBoolean(Convert.ToInt32(configuracionesGlobales(3)));
            estilosbtnCobrar();
            EstilizarDataGridViewPOS(); 
            txtProducto.Focus(); // Enfocar el campo de producto al cargar el formulario
        }

        #region Asignacion de fecha inicial
        public void AsignarFecha()
        {
            // Asignar la fecha actual al control de fecha
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        #endregion

        #region Busqueda de cliente
        public void BuscarCliente()
        {
            // Crear un diccionario para los parámetros
            var parametros = new Dictionary<string, object>
            {
                    { "@rfc", txtRFC.Text }
                };
            // Ejecutar el procedimiento almacenado
            DataTable resultado = util.EjecutarSp("sp_ConsultarReceptor", parametros);
            if (resultado.Rows.Count != 0)
            {
                // Si se encuentra el cliente, asignar los valores a los controles
                txtNombreCliente.Text = resultado.Rows[0]["RazonSocial"].ToString();
                txtUsoCFDI.Text = resultado.Rows[0]["UsoCFDI"].ToString();
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

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido del sistema
                                           // 
                if (!ValidarProductoCobrado())
                {
                    BuscarProducto();
                }                
                txtProducto.Text = "";
                txtCantidad.Text = "1"; // Reiniciar la cantidad a 1
            }
        }

       

        #region Buscar Producto
        public void BuscarProducto()
        {
            DataTable dtProducto = util.EjecutarSp("sp_ConsultarProductoPV", new Dictionary<string, object> { { "@codigo", txtProducto.Text } });
            foreach (DataRow row in dtProducto.Rows)
            {
                if (ValidarExistenciasProducto(int.Parse(txtCantidad.Text), int.Parse(row["Existencias"].ToString())))
                {
                    // Añadir nueva fila al DataGridView
                    int rowIndex = dgProductos.Rows.Add();

                    // Asignar valores a columnas específicas
                    dgProductos.Rows[rowIndex].Cells["colCodigo"].Value = row["CodigoDeBarras"];
                    dgProductos.Rows[rowIndex].Cells["colNombre"].Value = row["Nombre"];
                    dgProductos.Rows[rowIndex].Cells["colCostoUnitario"].Value = row["CostoUnitario"];
                    dgProductos.Rows[rowIndex].Cells["colCantidad"].Value = txtCantidad.Text;
                    dgProductos.Rows[rowIndex].Cells["colTotal"].Value = int.Parse(txtCantidad.Text) * decimal.Parse(row["CostoUnitario"].ToString());
                    dgProductos.Rows[rowIndex].Cells["colExistencia"].Value = row["Existencias"];
                    dgProductos.Rows[rowIndex].Cells["colFotografia"].Value = row["Fotografia"];
                    dgProductos.Rows[rowIndex].Cells["colDesc"].Value = row["DescripcionCorta"];
                    MostrarImagen(row["Fotografia"] as byte[]);
                }               
            }
            
            validarTotal(ConvertGridToTable(dgProductos));
        }
        public void MostrarImagen(byte[] byteImg)
        {
            Image imagen = imgz.ByteArrayToImage(byteImg);
            pbImgProducto.BackgroundImage = imagen;
            pbImgProducto.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void validarTotal(DataTable dt)
        {
            decimal suma = dt.AsEnumerable().Sum(row => row.Field<decimal>("colTotal"));
            lbTotal.Text = suma.ToString("C2");
            if (!facturacion)
            {
                txtSubtotal.Text = suma.ToString("C2");
                txtTotal.Text = suma.ToString("C2");
            }
        }
        private bool ValidarProductoCobrado()
        {
            if(dgProductos.Rows.Count != 0)
            {
                DataTable dtDatos = ConvertGridToTable(dgProductos);

                validarTotal(dtDatos);

                 // Buscar un valor específico (ejemplo: buscar ID = 5)
                 DataRow resultado = dtDatos.AsEnumerable()
                    .Where(row => row.Field<string>("colCodigo") == txtProducto.Text)
                    .FirstOrDefault();

                if (resultado != null)
                {
                    // Editar los valores si se encontró
                    resultado["colCantidad"] = int.Parse(resultado["colCantidad"].ToString()) + int.Parse(txtCantidad.Text);
                    resultado["colTotal"] =int.Parse(resultado["colCantidad"].ToString()) * decimal.Parse(resultado["colCostoUnitario"].ToString());

                    if(ValidarExistenciasProducto(int.Parse(resultado["colCantidad"].ToString()) , int.Parse(resultado["colExistencia"].ToString())))
                    {
                        // Actualizar el DataGridView
                        ActualizarGridDesdeTable(dgProductos, dtDatos);
                        // Opcional: Enfocar la fila encontrada
                        int rowIndex = dtDatos.Rows.IndexOf(resultado);
                        dgProductos.Rows[rowIndex].Selected = true;
                        dgProductos.FirstDisplayedScrollingRowIndex = rowIndex;
                        return true;
                    }
                    else
                    {
                        // Eliminar la fila del DataGridView
                        dgProductos.Rows.RemoveAt(dgProductos.Rows.Count - 1);
                        return false;
                    }   
                }
                else 
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool ValidarExistenciasProducto(int cantidad, int existencia)
        {
            if (cantidad > existencia)
            {
                MessageBox.Show("No hay suficiente existencia del producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }
            else
            {
                return true;
            }

        }

        private void ActualizarGridDesdeTable(DataGridView dgv, DataTable dt)
        {
            dgv.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int rowIndex = dgv.Rows.Add();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dgv.Rows[rowIndex].Cells[i].Value = row[i];
                }
            }
        }

        private DataTable ConvertGridToTable(DataGridView dgv)
        {
            var dt = new DataTable();

            // Crear columnas conservando tipos de datos
            dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(col =>
            {
                dt.Columns.Add(col.Name, col is DataGridViewImageColumn ? typeof(byte[]) : typeof(object));
            });

            // Convertir filas
            dgv.Rows.Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .ToList()
                .ForEach(row =>
                {
                    var dr = dt.NewRow();

                    row.Cells.Cast<DataGridViewCell>().ToList().ForEach(cell =>
                    {
                        dr[cell.ColumnIndex] = dgv.Columns[cell.ColumnIndex] is DataGridViewImageColumn
                            ? (cell.Value is Image ? ImageToByteArray((Image)cell.Value) : cell.Value)
                            : cell.Value;
                    });

                    dt.Rows.Add(dr);
                });

            return dt;
        }

        // Método para convertir Image a byte[]
        private byte[] ImageToByteArray(Image image)
        {
            if (image == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        #endregion

        private void dgProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgProductos.SelectedRows[0];
                byte[] arreglo = filaSeleccionada.Cells["colFotografia"].Value as byte[];


                if (arreglo != null && arreglo.Length > 0)
                {
                    try
                    {
                        Image imagen = imgz.ByteArrayToImage(arreglo);
                        pbImgProducto.BackgroundImage = imagen;
                        pbImgProducto.BackgroundImageLayout = ImageLayout.Stretch;
                        // Liberar la imagen anterior si existe
                        if (pbImgProducto.Tag is Image oldImage)
                        {
                            oldImage.Dispose();
                        }
                        pbImgProducto.Tag = imagen;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                        pbImgProducto.BackgroundImage = Properties.Resources.LogoRecortado;
                    }
                }
                else
                {
                    pbImgProducto.BackgroundImage = Properties.Resources.LogoRecortado;
                }
            }
        }

        private void txtCantidadPagada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido del sistema
                lbCambio.Text = "$" + (decimal.Parse(txtCantidadPagada.Text) - decimal.Parse(lbTotal.Text.Replace("$", "").Replace(",", ""))).ToString();
            }
        }

        private void btnConsultarRFC_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        #region Configuraciones Globales
        public string configuracionesGlobales(int idConfiguracion)
        {
            string Valor = "";
            // Crear un diccionario para los parámetros
            var parametros = new Dictionary<string, object>
            {
                    { "@idConfiguracion", idConfiguracion }
                };
            // Ejecutar el procedimiento almacenado
            DataTable resultado = util.EjecutarSp("sp_ConsultarCfg", parametros);
            if (resultado.Rows.Count != 0)
            {
                Valor = resultado.Rows[0]["valor"].ToString();
            }

            return Valor;
        }
        #endregion

        #region Estilos del boton cobrar

        // Agregar este método a tu clase
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public void estilosbtnCobrar()
        {
            btnCobrar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCobrar.Width, btnCobrar.Height, 20, 20));
            btnCancelar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCobrar.Width, btnCobrar.Height, 20, 20));
        
        }

        private void txtProducto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                MessageBox.Show("Se presionó F5 - Mostrar ayuda", "Tecla Detectada",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Tu código aquí
                e.IsInputKey = true; // Indicar que queremos manejar esta tecla
            }
        }

        private void EstilizarDataGridViewPOS()
        {
            // Configuración básica
            dgProductos.BorderStyle = BorderStyle.None;
            dgProductos.BackgroundColor = Color.FromArgb(45, 45, 48); // Fondo oscuro elegante
            dgProductos.GridColor = Color.FromArgb(64, 64, 64);

            // Fuente y color de texto
            dgProductos.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgProductos.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgProductos.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgProductos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul de selección

            // Estilo de encabezados de columnas
            dgProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgProductos.EnableHeadersVisualStyles = false;
            dgProductos.ColumnHeadersHeight = 40;

            // Estilo de filas alternas
            dgProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);

            // Configuración de selección
            dgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgProductos.MultiSelect = false;
            dgProductos.RowHeadersVisible = false; // Ocultar los headers de filas

            // Ajustes de renderizado
            dgProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgProductos.RowTemplate.Height = 35;

            // Efecto hover
            dgProductos.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Configurar columnas específicas (ejemplo)
            if (dgProductos.Columns.Count > 0)
            {
                // Columna de Precio (derecha-alineada)
                if (dgProductos.Columns.Contains("colPrecio"))
                {
                    dgProductos.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgProductos.Columns["colPrecio"].DefaultCellStyle.Format = "C2"; // Formato de moneda
                    dgProductos.Columns["colPrecio"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    dgProductos.Columns["colPrecio"].DefaultCellStyle.ForeColor = Color.FromArgb(0, 200, 83); // Verde para precios
                }

                // Columna de Cantidad (centrada)
                if (dgProductos.Columns.Contains("Cantidad"))
                {
                    dgProductos.Columns["colCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Columna de Importe (resaltada)
                if (dgProductos.Columns.Contains("colTotal"))
                {
                    dgProductos.Columns["colTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgProductos.Columns["colTotal"].DefaultCellStyle.Format = "C2";
                    dgProductos.Columns["colTotal"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    dgProductos.Columns["colTotal"].DefaultCellStyle.ForeColor = Color.FromArgb(255, 171, 25); // Amarillo/naranja
                    dgProductos.Columns["colTotal"].DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                }
            }

            // Ajustar automáticamente el tamaño de las columnas
            dgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Deshabilitar edición directa
            dgProductos.ReadOnly = true;
        }


        #endregion
    }
}
