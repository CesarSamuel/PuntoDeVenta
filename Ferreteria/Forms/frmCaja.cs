using Ferreteria.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.Forms
{
    public partial class frmCaja : Form
    {
        utilidades util = new utilidades();
        public DateTime FechaApertura;
        public decimal MontoApertura;
        public int IdSucursal, IdUsuario, IdCaja;
        public frmCaja(int IdSucursal, int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            this.IdSucursal = IdSucursal;
        }


        private void frmCaja_Load(object sender, EventArgs e)
        {
            if (!ValidarCaja())
            {
                txtMontoApertura.Enabled = true;
                txtFechaApertura.Text = DateTime.Now.ToString();
                btnAbrir.Enabled = true;
            }
            else
            {
                ConsultarCaja();
                txtMontoApertura.Enabled = false;
                txtFechaApertura.Text = FechaApertura.ToString();
                txtMontoApertura.Text = MontoApertura.ToString();
                btnAbrir.Enabled = false;
                btnCancelar.Enabled = true;
                txtMontoCierre.Enabled = true;
                var parametros = new Dictionary<string, object>
            {
                    { "@FechaInicio", FechaApertura },
                    { "@FechaFin", DateTime.Now.ToString() }
                };
                DataTable dtProducto = util.EjecutarSp("sp_ObtenerReporteVentas",parametros);
                ConsultarVentasDetalles(dtProducto);
                decimal suma = dtProducto.AsEnumerable().Sum(row => row.Field<decimal>("Total"));
                txtMontoVentas.Text = suma.ToString("C2");
                txtNumeroVentas.Text = dtProducto.Rows.Count.ToString();
            }

        }

        #region Consultar Ventas encabezado
        public void ConsultarVentasDetalles(DataTable dtProducto)
        {
            foreach (DataRow row in dtProducto.Rows)
            {
                // Añadir nueva fila al DataGridView
                int rowIndex = dgVentas.Rows.Add();

                // Asignar valores a columnas específicas
                dgVentas.Rows[rowIndex].Cells["colId"].Value = row["VentaId"];
                dgVentas.Rows[rowIndex].Cells["colFecha"].Value = row["Fecha"];
                dgVentas.Rows[rowIndex].Cells["colTotal"].Value = row["Total"];
                dgVentas.Rows[rowIndex].Cells["colItems"].Value = row["Items"];
            }
        }
        #endregion
        public void ConsultarCaja()
        {
            DataTable resultado = util.EjecutarSp("sp_ConsultarCaja");
            FechaApertura = Convert.ToDateTime(resultado.Rows[0]["FechaCreacion"]);
            MontoApertura = Convert.ToDecimal(resultado.Rows[0]["MontoApertura"]);
            IdCaja = Convert.ToInt32(resultado.Rows[0]["id"]);
        }

        private bool ValidarCaja()
        {
            DataTable resultado = util.EjecutarSp("sp_ValidarCaja");
            if (resultado.Rows[0]["ESTADO"].ToString() == "Abierta")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            AbrirCaja();
        }

        public bool ValidarApertura()
        {
            if(txtMontoApertura.Text == "")
            {
                MessageBox.Show("El monto de apertura no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }                
        }

        public void AbrirCaja()
        {
            var parametros = new Dictionary<string, object>
            {
                    { "@MontoApertura", ObtenerValorNumerico(txtMontoApertura) },
                    { "@IdSucursal", IdSucursal },
                    { "@IdUsuario", IdUsuario }
                };
            DataTable resultado = util.EjecutarSp("sp_AbrirCaja", parametros);
            if (resultado.Rows[0]["Resultado"].ToString() == "Insert Correcto")
            {
                MessageBox.Show("La caja se ha abierto correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al abrir la caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ValidarCierre();
        }

        public void ValidarCierre()
        {
            if (txtMontoCierre.Text == "")
            {
                MessageBox.Show("El monto de cierre no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CerrarCaja();
            }
        }

        private void CerrarCaja()
        {
            decimal montoCierre = ObtenerValorNumerico(txtMontoCierre);
            decimal montoApertura = ObtenerValorNumerico(txtMontoApertura);
            decimal montoVentas = ObtenerValorNumerico(txtMontoVentas);
            lbTotal.Text = "$" + (montoCierre - (montoApertura + montoVentas)).ToString(); 
            if ((montoCierre - (montoApertura + montoVentas)) < 0)
            {
                lbTotal.ForeColor = Color.Red;
            }
            else
            {
                lbTotal.ForeColor = Color.LimeGreen;
            }
            if (montoCierre != (montoApertura + montoVentas))
            {
                MessageBox.Show("El monto de cierre no coincide con el monto de apertura y las ventas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DialogResult Pregunta = MessageBox.Show(
                "¿Está seguro que desea Cerrar la caja",
                "Cierrre de caja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (Pregunta == DialogResult.Yes)
                {
                    var parametros = new Dictionary<string, object>
                {
                    { "@MontoCierre", ObtenerValorNumerico(txtMontoCierre) },
                    { "@IdUsuario", IdUsuario },
                    { "@IdSucursal", IdSucursal },
                    { "@IdCaja", IdCaja }
                };
                    DataTable resultado = util.EjecutarSp("sp_CerrarCaja", parametros);
                    if (resultado.Rows[0]["Resultado"].ToString() == "Update Correcto")
                    {
                        MessageBox.Show("La caja se ha cerrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al cerrar la caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Código si el usuario cancela
                    MessageBox.Show("Operación cancelada");
                }
            }
                
        }

        private void txtMontoApertura_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            KeyPressb(sender, e);
        }

        private void txtMontoApertura_Enter(object sender, EventArgs e)
        {
            EnterPress(sender);
        }

        private void txtMontoApertura_Leave(object sender, EventArgs e)
        {
            LeavePress(sender);
        }
        
        private void txtMontoApertura_TextChanged(object sender, EventArgs e)
        {
            TextChangedPress(sender);
        }

        private void txtMontoApertura_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownPress(e);
        }

        private void txtMontoCierre_TextChanged(object sender, EventArgs e)
        {
            TextChangedPress(sender);
        }

        private void txtMontoCierre_Leave(object sender, EventArgs e)
        {
            LeavePress(sender);
        }

        private void txtMontoCierre_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownPress(e);    
        }

        private void txtMontoCierre_Enter(object sender, EventArgs e)
        {
            EnterPress(sender);
        }

        private void txtMontoCierre_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressb(sender, e);
        }

        public void EnterPress(object sender)
        {
            TextBox textBox = (TextBox)sender;

            // Al entrar, seleccionar solo la parte numérica
            if (textBox.Text.StartsWith("$"))
            {
                textBox.SelectionStart = 1;
                textBox.SelectionLength = textBox.Text.Length - 1;
            }
        }

        public void LeavePress(object sender)
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

        public void TextChangedPress(object sender)
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

        public void KeyDownPress(KeyEventArgs e)
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

        

        public decimal ObtenerValorNumerico(TextBox txt)
        {
            string valorSinSigno = txt.Text.Replace("$", "");
            if (decimal.TryParse(valorSinSigno, out decimal valor))
            {
                return valor;
            }
            return 0.00m;
        }

        public void KeyPressb(object sender, KeyPressEventArgs e)
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
    }
}
