using Ferreteria.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;

namespace Ferreteria.Forms
{
    public partial class frmAddProducto : Form
    {
        #region Variables Globales
        utilidades util = new utilidades();
        public int IdUsuario;
        #endregion 

        #region Constructor
        public frmAddProducto(int idUsuario)
        {
            IdUsuario = idUsuario;
            InitializeComponent();
        }
        #endregion

        #region Boton Examinar para buscar imagenes
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes (*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Verificar que el archivo es una imagen válida
                        using (var tempImage = Image.FromFile(openFileDialog.FileName))
                        {
                            // Si llegamos aquí, la imagen es válida
                            string rutaImagen = openFileDialog.FileName;
                            txtRutaImagen.Text = rutaImagen;
                            pbImagen.BackgroundImage = (Image)tempImage.Clone();
                            pbImagen.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"El archivo seleccionado no es una imagen válida: {ex.Message}",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Load del formulario
        private void frmAddProducto_Load(object sender, EventArgs e)
        {
            txtMonto.Text = "$0.00";
            llenarDepartamentos();
            llenarSucursales();
        }
        #endregion

        #region Llenar Combobox
        public void llenarDepartamentos()
        {
            DataTable departamentosDt = util.EjecutarSp("sp_ConsultarDepartamentos");
            var datos = departamentosDt.AsEnumerable()
                   .Select(row => new
                   {
                       id = row.Field<int>("id"),
                       Nombre = row.Field<string>("Nombre")
                   })
            .ToList();

            cboDepartamento.DataSource = datos;
            cboDepartamento.DisplayMember = "Nombre";
            cboDepartamento.ValueMember = "id";
        }

        public void llenarSucursales()
        {
            DataTable departamentosDt = util.EjecutarSp("sp_ConsultarSucursales");
            var datos = departamentosDt.AsEnumerable()
                   .Select(row => new
                   {
                       id = row.Field<int>("id"),
                       Nombre = row.Field<string>("Nombre")
                   })
            .ToList();

            cboSucursal.DataSource = datos;
            cboSucursal.DisplayMember = "Nombre";
            cboSucursal.ValueMember = "id";
        }
        #endregion

        #region Cerrado de formulario
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Validaciones de campos 

        #region Validaciones campo monto
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Permitir: dígitos (0-9), backspace, punto decimal (solo uno)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Validar que solo haya un punto decimal
            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                return;
            }

            // No permitir punto decimal al inicio
            if (e.KeyChar == '.' && textBox.SelectionStart == 1 && textBox.Text.StartsWith("$"))
            {
                e.Handled = true;
            }
        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Al entrar, seleccionar solo la parte numérica
            if (textBox.Text.StartsWith("$"))
            {
                textBox.SelectionStart = 1;
                textBox.SelectionLength = textBox.Text.Length - 1;
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (TextBox)sender;

            // Formatear al salir
            if (textBox.Text.StartsWith("$"))
            {
                string contenidoNumerico = textBox.Text.Substring(1);
                if (decimal.TryParse(contenidoNumerico, out decimal valor))
                {
                    textBox.Text = $"${valor.ToString("0.00")}";
                }
                else
                {
                    textBox.Text = "$0.00";
                }
            }
            else
            {
                if (decimal.TryParse(textBox.Text, out decimal valor))
                {
                    textBox.Text = $"${valor.ToString("0.00")}";
                }
                else
                {
                    textBox.Text = "$0.00";
                }
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Asegurar que siempre empiece con $
            if (!textBox.Text.StartsWith("$") && !string.IsNullOrEmpty(textBox.Text))
            {
                int cursorPos = textBox.SelectionStart;
                textBox.Text = "$" + textBox.Text.Replace("$", "");
                textBox.SelectionStart = cursorPos + 1;
            }
        }
        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            // Permitir atajos de teclado (Ctrl+V, Ctrl+C, etc.)
            if (e.Control && (e.KeyCode == Keys.V || e.KeyCode == Keys.C || e.KeyCode == Keys.X || e.KeyCode == Keys.A))
            {
                return;
            }

            // Permitir teclas de navegación
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
            {
                return;
            }

            // Bloquear tecla $ para evitar duplicados
            if (e.KeyCode == Keys.D4 && e.Shift) // Tecla $ (Shift+4)
            {
                e.SuppressKeyPress = true;
            }
        }
        public decimal ObtenerValorNumerico()
        {
            string valorSinSigno = txtMonto.Text.Replace("$", "");
            if (decimal.TryParse(valorSinSigno, out decimal valor))
            {
                return valor;
            }
            return 0.00m;
        }
        #endregion

        #region Validacion de enteros 
        private void txtExistencias_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir dígitos (0-9), backspace (8) y tecla de suprimir (127)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Rechazar el carácter
            }

            // Opcional: Permitir signo negativo (para números negativos)
            // if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') == -1))
            // {
            //     return;
            // }
        }
        #endregion

        #region Enter en campo de codigo de barras
        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido del sistema                                           
                cboDepartamento.Focus();
            }
        }

        #endregion

        #endregion

        #region Guardar Producto
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposProducto())
            {
                // Obtener los valores de los campos
                string nombre = txtNombre.Text;
                string descCorta = txtDescCorta.Text;
                string descLarga = txtDescLarga.Text;
                decimal costoUnitario = ObtenerValorNumerico();
                string codigoBarras = txtCodigoBarras.Text;
                int idDepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);
                int existencias = Convert.ToInt32(txtExistencias.Text);
                string rutaImagen = txtRutaImagen.Text;
                int idSucursal = Convert.ToInt32(cboSucursal.SelectedValue);

                // Crear un diccionario para los parámetros
                var parametros = new Dictionary<string, object>
                {
                    { "@Nombre", nombre },
                    { "@DescripcionCorta", descCorta },
                    { "@DescripcionLarga", descLarga },
                    { "@CostoUnitario", costoUnitario },
                    { "@Existencias", existencias },
                    { "@CodigoDeBarras", codigoBarras },
                    { "@RutaImagen", rutaImagen },
                    { "@UsuarioCreadorId", IdUsuario },
                    { "@DepartamentoId", idDepartamento },
                    { "@SucursalId", idSucursal }
                    
                    
                };
                // Ejecutar el procedimiento almacenado
                DataTable resultado = util.EjecutarSp("sp_InsertarProducto", parametros);
                if (resultado.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Producto guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto. \n " + resultado.Rows[0][1].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool ValidarCamposProducto()
        {
            if (!validarCampo(txtNombre.Text)) {
                MessageBox.Show("Favor de agregar un nombre de prodcuto", "Error en Nombre de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (!validarCampo(txtDescCorta.Text)) {
                MessageBox.Show("Favor de agregar una descripcion corta", "Error en Descripcion corta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (!validarCampo(txtDescLarga.Text)) {
                MessageBox.Show("Favor de agregar una descripcion larga", "Error en Descripcion larga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (!validarCampo(txtMonto.Text)) { 
                MessageBox.Show("Favor de agregar un monto", "Error en Monto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (!validarCampo(txtCodigoBarras.Text)) {
                if (txtCodigoBarras.Text.Length < 8) {
                    MessageBox.Show("Favor de agregar un codigo de barras valido", "Error en Codigo de barras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }else{ return false; }
            } else if (!validarCampo(cboDepartamento.Text)) {
                MessageBox.Show("Favor de seleccionar un departamento", "Error en Departamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }else if (!validarCampo(cboSucursal.Text)) {
                MessageBox.Show("Favor de seleccionar una sucursal", "Error en Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else if (!validarCampo(txtExistencias.Text)) {
                if (txtExistencias.Text.Length < 1) {
                    MessageBox.Show("Favor de agregar un valor valido en existencias", "Error en Existencias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }else { return false; }
            } else if (!validarCampo(txtRutaImagen.Text)) {
                MessageBox.Show("Favor de agregar una imagen", "Error en Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else {
                return true;
            }
        }

        public bool validarCampo(string campo)
        {
            if (string.IsNullOrEmpty(campo) || string.IsNullOrWhiteSpace(campo) || campo == string.Empty || campo == ""){
                return false;
            }else{
                return true;
            }
        }

        public void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtDescCorta.Text = "";
            txtDescLarga.Text = "";
            txtExistencias.Text = "";
            txtMonto.Text = "$0.00";
            txtRutaImagen.Text = "";
            cboDepartamento.SelectedIndex = -1;
            cboSucursal.SelectedIndex = -1;
            txtCodigoBarras.Text = "";
            txtNombre.Focus();
        }
        #endregion

        #region Limpiar campos
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }
        #endregion
    }
}
