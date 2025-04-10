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
        public int IdUsuario, idVenta;
        public decimal IVA;
        public bool descuentos, facturacion;
        utilidades util = new utilidades();
        Imagenes imgz = new Imagenes();
        Estilos estilos = new Estilos();
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
            estilos.EstilizarDataGridViewPOS(dgProductos);
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
                    dgProductos.Rows[rowIndex].Cells["colId"].Value = row["Id"];
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
            if (dgProductos.Rows.Count != 0)
            {
                DataTable dtDatos = ConvertGridToTable(dgProductos);

                // Buscar un valor específico (ejemplo: buscar ID = 5)
                DataRow resultado = dtDatos.AsEnumerable()
                   .Where(row => row.Field<string>("colCodigo") == txtProducto.Text)
                   .FirstOrDefault();

                if (resultado != null)
                {
                    // Editar los valores si se encontró
                    resultado["colCantidad"] = int.Parse(resultado["colCantidad"].ToString()) + int.Parse(txtCantidad.Text);
                    resultado["colTotal"] = int.Parse(resultado["colCantidad"].ToString()) * decimal.Parse(resultado["colCostoUnitario"].ToString());

                    if (ValidarExistenciasProducto(int.Parse(resultado["colCantidad"].ToString()), int.Parse(resultado["colExistencia"].ToString())))
                    {
                        // Actualizar el DataGridView
                        ActualizarGridDesdeTable(dgProductos, dtDatos);
                        // Opcional: Enfocar la fila encontrada
                        int rowIndex = dtDatos.Rows.IndexOf(resultado);
                        dgProductos.Rows[rowIndex].Selected = true;
                        dgProductos.FirstDisplayedScrollingRowIndex = rowIndex;
                        validarTotal(dtDatos);
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
        public void Cambio()
        {
            lbCambio.Text = "$" + (decimal.Parse(txtCantidadPagada.Text) - decimal.Parse(lbTotal.Text.Replace("$", "").Replace(",", ""))).ToString();
        }

        private void txtCantidadPagada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido del sistema
                Cambio();
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


        #endregion


        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (validarVenta())
            {
                ComenzarGuardar();
            }
        }

        public void ComenzarGuardar()
        {
            // Crear formulario personalizado para pedir cantidad
            Form inputForm = new Form()
            {
                Width = 350,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Ingrese los datos de pago",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Contenedor principal
            Panel mainPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            // Control para la cantidad - MODIFICADO PARA INICIAR VACÍO
            NumericUpDown numericUpDown = new NumericUpDown()
            {
                Maximum = 1000000,
                DecimalPlaces = 2,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 12),
                Margin = new Padding(0, 0, 0, 10),
                Value = 0.00m,    // Inicia en 0.00
                Text = ""         // Texto vacío
            };

            // Configurar para que muestre vacío al inicio
            numericUpDown.Enter += (sender, e) =>
            {
                if (numericUpDown.Value == 0)
                {
                    numericUpDown.Text = "";
                }
            };

            // Validar cuando pierde el foco
            numericUpDown.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(numericUpDown.Text))
                {
                    numericUpDown.Value = 0.00m;
                }
            };

            // Grupo para los tipos de pago
            GroupBox paymentGroup = new GroupBox()
            {
                Text = "Método de pago",
                Dock = DockStyle.Top,
                Height = 80,
                Margin = new Padding(0, 0, 0, 10)
            };

            RadioButton rbEfectivo = new RadioButton()
            {
                Text = "Efectivo",
                Checked = true,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10)
            };

            RadioButton rbTarjeta = new RadioButton()
            {
                Text = "Tarjeta",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10)
            };

            // Botón Aceptar
            Button okButton = new Button()
            {
                Text = "Aceptar",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom,
                Height = 40,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White
            };

            // Agregar controles
            paymentGroup.Controls.Add(rbTarjeta);
            paymentGroup.Controls.Add(rbEfectivo);

            mainPanel.Controls.Add(okButton);
            mainPanel.Controls.Add(paymentGroup);
            mainPanel.Controls.Add(numericUpDown);

            inputForm.Controls.Add(mainPanel);
            inputForm.AcceptButton = okButton;

            // ESTABLECER EL FOCO EN EL CAMPO NUMÉRICO AL MOSTRAR EL FORMULARIO
            inputForm.Shown += (sender, e) =>
            {
                numericUpDown.Select();
                numericUpDown.Select(0, numericUpDown.Text.Length);
            };

            // Validación al aceptar
            okButton.Click += (sender, e) =>
            {
                if (decimal.Parse(numericUpDown.Value.ToString()) < decimal.Parse(txtTotal.Text.Replace("$", "")))
                {
                    MessageBox.Show("Ingrese una cantidad válida", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numericUpDown.Focus();
                    inputForm.DialogResult = DialogResult.None;
                }
            };
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                decimal cantidad = numericUpDown.Value;
                bool esEfectivo = rbEfectivo.Checked;
                // Usar la cantidad ingresada
                txtCantidadPagada.Text = cantidad.ToString();
                Cambio();
                guardarVenta();
            }
        }

        private void txtProducto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                // Tu código aquí
                e.IsInputKey = true; // Indicar que queremos manejar esta tecla
                if (validarVenta())
                {
                    ComenzarGuardar();
                }
            }
        }

        #region Guardar Venta
        public bool guardarVenta()
        {
            if (RecopilarDatosVentaEncabezado())
            {
                if (RecopilarDatosVentaDetalle(ConvertGridToTable(dgProductos)))
                {
                    MessageBox.Show("Venta generada con éxito \n Su cambio es: " + lbCambio.Text, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    txtProducto.Focus();
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al generar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                   
            }
            else
            {
                return false;
            }
        }

       

        public bool validarVenta()
        {
            if (dgProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtTotal.Text == "$0.00")
            {
                MessageBox.Show("No hay productos en la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool RecopilarDatosVentaEncabezado()
        {
            // Crear un diccionario para los parámetros
            var parametros = new Dictionary<string, object>
            {
                { "@Total", decimal.Parse(txtTotal.Text.Replace("$", "").Replace(",", "")) },
                { "@EmisorId", 1 },
                { "@ReceptorId", idCliente },
                { "@UsuarioId", IdUsuario },
                { "@SucursalId", 1 },
                { "@Comentario", txtComentario.Text }
            };
            // Ejecutar el procedimiento almacenado
            DataTable resultado = util.EjecutarSp("sp_InsertarVentaEncabezado", parametros);
            if(ValidarSpProducto(resultado))
            {
                idVenta = int.Parse(resultado.Rows[0][1].ToString());
                return true;
            }
            else
            {
                return false;
            }            
        }

        public bool ValidarSpProducto(DataTable resultado)
        {
            if (resultado.Rows[0][0].ToString() == "1")
            {
                return true;
            }
            else
            {

                MessageBox.Show("Error al guardar el producto. \n " + resultado.Rows[0][1].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool RecopilarDatosVentaDetalle(DataTable dataTable)
        {
            bool proceso = false; ; 
            foreach(DataRow row in dataTable.Rows){
                var parametros = new Dictionary<string, object>
            {
                { "@VentaId", idVenta },
                { "@ProductoId", row.Field<int>("colId") },
                { "@Cantidad",int.Parse(row["colCantidad"].ToString()) },
                { "@PrecioUnitario", row.Field<decimal>("colCostoUnitario") },
                { "@Importe", row.Field<decimal>("coltotal") }
            };
                // Ejecutar el procedimiento almacenado
                DataTable resultado = util.EjecutarSp("sp_InsertarVentaDetalle", parametros);
                if (ValidarSpProducto(resultado))
                {
                    proceso =  true;
                }
                else
                {
                    proceso = false;
                }
            }
            return proceso;
        }

        public void Limpiar()
        {
            dgProductos.Rows.Clear();
            lbTotal.Text = "$0.00";
            lbCambio.Text = "$0.00";
            txtCantidad.Text = "1";
            txtCantidadPagada.Text = "0";
            txtComentario.Text = "";
            txtSubtotal.Text = "$0.00";
            txtTotal.Text = "$0.00";
            txtRFC.Text = "XAXX010101000";
            BuscarCliente();
            pbImgProducto.BackgroundImage = Properties.Resources.LogoRecortado;
        }

        

        #endregion
    }
}
