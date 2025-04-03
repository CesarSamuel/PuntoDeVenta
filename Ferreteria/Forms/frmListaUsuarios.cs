using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.Forms
{
    public partial class frmListaUsuarios : Form
    {
        Conexion.utilidades util = new Conexion.utilidades();   
        private DataTable datosOriginales; // Para guardar los datos sin filtrar

        public frmListaUsuarios()
        {
            InitializeComponent();
        }

        #region Load de la pantalla 
        private void frmListaUsuarios_Load(object sender, EventArgs e)
        {
            llenarGridUsuarios();
        }
        #endregion

        #region Llenar Grid de usuarios 
        public void llenarGridUsuarios()
        {
            DataTable dtUsuarios = util.EjecutarSp("sp_ListaUsuarios");
            // Asignar el DataTable directamente al DataSource del DataGridView
            dgListaUsuarios.DataSource = dtUsuarios;
            datosOriginales = dtUsuarios;
            // Configuración opcional para mejorar la visualización
            dgListaUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgListaUsuarios.AutoResizeColumns();
        }
        #endregion

        #region Buscador de datos
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (datosOriginales == null) return;

            string textoBusqueda = txtBuscador.Text.Trim();

            // Usar DataView para el filtrado
            DataView vista = new DataView(datosOriginales);

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                vista.RowFilter = string.Empty;
            }
            else
            {
                vista.RowFilter = GenerarFiltroGlobal(textoBusqueda);
            }

            dgListaUsuarios.DataSource = vista;
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
        #endregion

        #region Doble clic en DataGridView
        private void dgListaUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que el clic no fue en los encabezados de columna/fila
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow fila = dgListaUsuarios.Rows[e.RowIndex];

                string id = fila.Cells["Id"].Value?.ToString();
                string tipoUsuario = fila.Cells["TipoUsuario"].Value?.ToString();

                DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea modificar este Usuario?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Código si el usuario confirma
                    ModificarUsuario(tipoUsuario,id);
                }
                else
                {
                    // Código si el usuario cancela
                    MessageBox.Show("Operación cancelada");
                }
            }
        }
        #endregion

        #region Modificacion de usuario
        public void ModificarUsuario(string tipoUsuario, string idUsuario)
        {
            frmAddUser frmAddUser = new frmAddUser(tipoUsuario, idUsuario); 
            frmAddUser.FormClosed += (sender, e) =>
            {
                llenarGridUsuarios();
            };
            frmAddUser.ShowDialog();    
        }
        #endregion
    }
}
