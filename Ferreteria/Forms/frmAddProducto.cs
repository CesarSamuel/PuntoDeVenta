using Ferreteria.Conexion;
using Ferreteria.Utilidades;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;

namespace Ferreteria.Forms
{
    public partial class frmAddProducto : Form
    {
        #region Variables Globales
        utilidades util = new utilidades();
        Imagenes imgz = new Imagenes();
        public int IdUsuario, IdProducto, idDepartamento, existencias, idSucursal;
        public string nombre, descCorta, descLarga, codigoBarras, rutaImagen;
        public decimal costoUnitario;
        public byte[] imgBytes, ImagenProducto;
        #endregion

        #region Constructor
        public frmAddProducto(int idUsuario, int idProducto = 0)
        {
            this.IdUsuario = idUsuario;
            this.IdProducto = idProducto;
            InitializeComponent();
        }
        #endregion

        #region Boton Examinar para buscar imagenes
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes (*.jpg; *.jpeg; *.png; *.webp)|*.jpg; *.jpeg; *.png; *.webp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string rutaImagen = openFileDialog.FileName;
                        txtRutaImagen.Text = rutaImagen;

                        if (Path.GetExtension(rutaImagen).ToLower() == ".webp")
                        {
                            // Configuración para evitar problemas de memoria
                            var settings = new MagickReadSettings
                            {
                                Density = new Density(300, 300) // Ajusta según necesidad
                            };

                            using (var image = new MagickImage(rutaImagen, settings))
                            {
                                // Convertir a formato compatible con Bitmap
                                image.Format = MagickFormat.Bmp;

                                // Crear MemoryStream y cargar en Bitmap
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    image.Write(ms);
                                    ms.Position = 0;
                                    pbImagen.BackgroundImage = new Bitmap(ms);
                                }
                            }
                        }
                        else
                        {
                            // Para formatos nativos
                            pbImagen.BackgroundImage = Image.FromFile(rutaImagen);
                        }

                        pbImagen.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la imagen: {ex.Message}\n\nDetalle técnico: {ex.ToString()}",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Agrega esta clase helper
        public static class WebPHelper
        {
            public static Image WebPToImage(string webPPath)
            {
                // Implementación usando alguna librería de conversión
                // Esto es un ejemplo conceptual
                byte[] webPBytes = File.ReadAllBytes(webPPath);
                return ConvertWebPToBitmap(webPBytes); // Necesitarías una librería real aquí
            }

            private static Image ConvertWebPToBitmap(byte[] webPData)
            {
                // Implementación real necesitaría una librería como WebPWrapper
                throw new NotImplementedException("Requiere librería de conversión WebP");
            }
        }
        #endregion

        #region Load del formulario
        private void frmAddProducto_Load(object sender, EventArgs e)
        {
            txtMonto.Text = "$0.00";
            llenarDepartamentos();
            llenarSucursales();
            if (IdProducto != 0)
            {
                consutlarProducto();
            }
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

        #region Obtener campos
        public void ObtenerCampos()
        {
            nombre = txtNombre.Text;
            descCorta = txtDescCorta.Text;
            descLarga = txtDescLarga.Text;
            costoUnitario = ObtenerValorNumerico();
            codigoBarras = txtCodigoBarras.Text;
            idDepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);
            existencias = Convert.ToInt32(txtExistencias.Text);
            rutaImagen = txtRutaImagen.Text;
            if(rutaImagen == "")
            {
                imgBytes = ImagenProducto;
            }
            else
            {
                imgBytes = File.ReadAllBytes(rutaImagen);
            }
                
            idSucursal = Convert.ToInt32(cboSucursal.SelectedValue);
        }
        #endregion

        #endregion

        #region Guardar Producto
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(IdProducto == 0)
            {
                GuardarProducto();
            }
            else
            {
                ModificarProducto();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea Eliminar este Producto?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Código si el usuario confirma
                EliminarProducto();
            }
            else
            {
                // Código si el usuario cancela
                MessageBox.Show("Operación cancelada");
            }
        }

        private void EliminarProducto()
        {
            DataTable resultado = util.EjecutarSp("sp_EliminarProducto",
                        new Dictionary<string, object>
                        {
                            ["IdProducto"] = IdProducto
                        });
            if (resultado.Rows[0][0].ToString() == "Eliminacion Correcta")
            {
                MessageBox.Show("Producto Eliminado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public void GuardarProducto()
        {
            if (ValidarCamposProducto())
            {
                // Obtener los valores de los campos
                ObtenerCampos();

                // Crear un diccionario para los parámetros
                var parametros = new Dictionary<string, object>
                {
                    { "@Nombre", nombre },
                    { "@DescripcionCorta", descCorta },
                    { "@DescripcionLarga", descLarga },
                    { "@CostoUnitario", costoUnitario },
                    { "@Existencias", existencias },
                    { "@CodigoDeBarras", codigoBarras },
                    { "@Fotografia", imgBytes }, 
                    { "@UsuarioCreadorId", IdUsuario },
                    { "@DepartamentoId", idDepartamento },
                    { "@SucursalId", idSucursal }


                };
                // Ejecutar el procedimiento almacenado
                DataTable resultado = util.EjecutarSp("sp_InsertarProducto", parametros);
                ValidarSpProducto(resultado);
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
            } else if(IdProducto == 0) {
                if (!validarCampo(txtRutaImagen.Text))
                {
                    MessageBox.Show("Favor de agregar una imagen", "Error en Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }else {
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

        public void ValidarSpProducto(DataTable resultado)
        {
            if (resultado.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Producto guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar el producto. \n " + resultado.Rows[0][1].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Limpiar campos
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
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
            pbImagen.BackgroundImage = Properties.Resources.LogoRecortado;
        }
        #endregion

        #region Modificar Producto
        public void consutlarProducto()
        {
            DataTable dtProducto = util.EjecutarSp("sp_ConsultarProducto", new Dictionary<string, object> { { "@IdProducto", IdProducto } });
            if (dtProducto.Rows.Count > 0)
            {
                txtNombre.Text = dtProducto.Rows[0]["Nombre"].ToString();
                txtDescCorta.Text = dtProducto.Rows[0]["DescripcionCorta"].ToString();
                txtDescLarga.Text = dtProducto.Rows[0]["DescripcionLarga"].ToString();
                txtCodigoBarras.Text = dtProducto.Rows[0]["CodigoDeBarras"].ToString();
                txtExistencias.Text = dtProducto.Rows[0]["Existencias"].ToString();
                cboDepartamento.SelectedValue = Convert.ToInt32(dtProducto.Rows[0]["DepartamentoId"]);
                cboSucursal.SelectedValue = Convert.ToInt32(dtProducto.Rows[0]["SucursalId"]);
                txtMonto.Text = "$" + dtProducto.Rows[0]["CostoUnitario"].ToString();
                pbImagen.BackgroundImage = imgz.ByteArrayToImage(dtProducto.Rows[0]["Fotografia"] as byte[]);
                ImagenProducto = dtProducto.Rows[0]["Fotografia"] as byte[];
            }
            btnGuardar.Text = "Modificar";
            btnEliminar.Visible = true;
        }

        public void ModificarProducto()
        {
            if (ValidarCamposProducto())
            {
                ObtenerCampos();
                var parametros = new Dictionary<string, object>
                {
                    { "@ProductoId", IdProducto },
                    { "@Nombre", nombre },
                    { "@DescripcionCorta", descCorta },
                    { "@DescripcionLarga", descLarga },
                    { "@CostoUnitario", costoUnitario },
                    { "@Existencias", existencias },
                    { "@CodigoDeBarras", codigoBarras },
                    { "@Fotografia", imgBytes ?? (object)DBNull.Value},
                    { "@UsuarioModificadorId", IdUsuario },
                    { "@DepartamentoId", idDepartamento },
                    { "@SucursalId", idSucursal }
                };
                DataTable resultado = util.EjecutarSp("sp_ActualizarProducto", parametros);
                ValidarSpProducto(resultado);
            }
        }
        #endregion
    }
}
