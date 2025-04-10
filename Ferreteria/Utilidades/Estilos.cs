using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.Utilidades
{
    public class Estilos
    {
        #region Estilos de dataGridView
        public void EstilizarDataGridViewPOS(DataGridView dgv)
        {
            // Configuración básica
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.FromArgb(45, 45, 48); // Fondo oscuro elegante
            dgv.GridColor = Color.FromArgb(64, 64, 64);

            // Fuente y color de texto
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgv.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul de selección

            // Estilo de encabezados de columnas
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 40;

            // Estilo de filas alternas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);

            // Configuración de selección
            //dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersWidth = 15; // Ancho de la columna de encabezado de filas
            //dgv.RowHeadersVisible = false; // Ocultar los headers de filas

            // Ajustes de renderizado
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowTemplate.Height = 35;

            // Efecto hover
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Configurar columnas específicas (ejemplo)
            if (dgv.Columns.Count > 0)
            {
                // Columna de Precio (derecha-alineada)
                if (dgv.Columns.Contains("colPrecio"))
                {
                    dgv.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv.Columns["colPrecio"].DefaultCellStyle.Format = "C2"; // Formato de moneda
                    dgv.Columns["colPrecio"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    dgv.Columns["colPrecio"].DefaultCellStyle.ForeColor = Color.FromArgb(0, 200, 83); // Verde para precios
                }

                // Columna de Cantidad (centrada)
                if (dgv.Columns.Contains("Cantidad"))
                {
                    dgv.Columns["colCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Columna de Importe (resaltada)
                if (dgv.Columns.Contains("colTotal"))
                {
                    dgv.Columns["colTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv.Columns["colTotal"].DefaultCellStyle.Format = "C2";
                    dgv.Columns["colTotal"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    dgv.Columns["colTotal"].DefaultCellStyle.ForeColor = Color.FromArgb(255, 171, 25); // Amarillo/naranja
                    dgv.Columns["colTotal"].DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                }
            }

            // Ajustar automáticamente el tamaño de las columnas
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Deshabilitar edición directa
            dgv.ReadOnly = true;
        }
        #endregion
    }
}
