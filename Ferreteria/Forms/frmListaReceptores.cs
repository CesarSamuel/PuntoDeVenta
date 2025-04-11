using Ferreteria.Conexion;
using Ferreteria.Utilidades;
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
    public partial class frmListaReceptores : Form
    {
        #region Variables Globales
        utilidades util = new utilidades();
        Estilos estilos = new Estilos();
        Filtros filtros = new Filtros();
        private DataTable datosOriginales; // Para guardar los datos sin filtrar
        #endregion

        public frmListaReceptores()
        {
            InitializeComponent();
        }

        private void frmListaReceptores_Load(object sender, EventArgs e)
        {
            DataTable dtReceptores = util.EjecutarSp("sp_ConsultarReceptores");
            ConsultarClientes(dtReceptores);
            datosOriginales = dtReceptores.Copy(); // Guardar una copia de los datos originales
            estilos.EstilizarDataGridViewPOS(dgListaClientes);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (datosOriginales == null) return;

            // 1. Configurar AutoGenerateColumns como false para evitar columnas duplicadas
            dgListaClientes.AutoGenerateColumns = false;

            // 2. Aplicar el filtro directamente al DataView existente
            string textoBusqueda = txtBuscador.Text.Trim();

            if (dgListaClientes.DataSource is DataView vistaExistente)
            {
                vistaExistente.RowFilter = string.IsNullOrWhiteSpace(textoBusqueda)
                    ? string.Empty
                    : filtros.GenerarFiltroGlobal(textoBusqueda, datosOriginales);
            }
            else
            {
                dgListaClientes.DataSource = new DataView(datosOriginales)
                {
                    RowFilter = string.IsNullOrWhiteSpace(textoBusqueda)
                        ? string.Empty
                        : filtros.GenerarFiltroGlobal(textoBusqueda, datosOriginales)
                };
            }
        }
        

        #region Consultar Clientes
        public void ConsultarClientes(DataTable dtClientes)
        {
            foreach (DataRow row in dtClientes.Rows)
            {
                // Añadir nueva fila al DataGridView
                int rowIndex = dgListaClientes.Rows.Add();

                // Asignar valores a columnas específicas
                dgListaClientes.Rows[rowIndex].Cells["colId"].Value = row["id"];
                dgListaClientes.Rows[rowIndex].Cells["colRfc"].Value = row["RFC"];
                dgListaClientes.Rows[rowIndex].Cells["colRazonSocial"].Value = row["RazonSocial"];
                dgListaClientes.Rows[rowIndex].Cells["colResidenciaFiscal"].Value = row["ResidenciaFiscal"];
                dgListaClientes.Rows[rowIndex].Cells["colDireccion"].Value = row["Direccion"];
                dgListaClientes.Rows[rowIndex].Cells["colUsoCfdi"].Value = row["UsoCFDI"];
            }
        }
        #endregion

       
    }
}
