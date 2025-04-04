using Ferreteria.Conexion;
using Ferreteria.Entidades;
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
    public partial class frmListaProductos : Form
    {
        #region Variables Globales
        utilidades util = new utilidades();
        public int IdUsuario;
        private DataTable datosOriginales; // Para guardar los datos sin filtrar
        #endregion

        #region Constructor
        public frmListaProductos(int idUsuario)
        {
            InitializeComponent();
            this.IdUsuario = idUsuario;
        }
        #endregion

        #region Load
        private void frmListaProductos_Load(object sender, EventArgs e)
        {
            llenarGridUsuarios();
        }
        #endregion

        #region llenado de Grid de productos 
        public void llenarGridUsuarios()
        {
            DataTable dtProductos = util.EjecutarSp("sp_ConsultarProductos");

            //List<ProductoVista> productos = dtProductos.AsEnumerable()
            //.Select(row => new ProductoVista
            //{
            //    Imagen = row.Field<byte[]>("Fotografia"),
            //    Nombre = row.Field<string>("Nombre"),
            //    Precio = row.Field<decimal>("CostoUnitario"),
            //    Stock = row.Field<int>("Existencias")
            //})
            //.ToList();

            //dgProductos.DataSource = productos;
            //// Configuración opcional para mejorar la visualización
            //dgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgProductos.AutoResizeColumns();

            // 1. Configurar el DataGridView
            dgProductos.Columns.Clear();

            // 2. Crear columna para la imagen
            //DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            //imgCol.DataPropertyName = "ImagenDisplay"; // Usa la propiedad que genera la imagen
            //imgCol.HeaderText = "Imagen";
            //imgCol.Name = "Imagen";
            //imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            //imgCol.Width = 120;
            //dgProductos.Columns.Add(imgCol);

            // 3. Agregar otras columnas necesarias
            //dgProductos.Columns.Add("Nombre", "Nombre del Producto");
            //dgProductos.Columns.Add("Precio", "Precio Unitario");
            dgProductos.RowTemplate.Height = 120;

            // 4. Cargar los datos
            List<ProductoVista> productos = dtProductos.AsEnumerable()
                .Select(row => new ProductoVista
                {
                    Imagen = row.Field<byte[]>("Fotografia"),
                    Nombre = row.Field<string>("Nombre"),
                    Precio = row.Field<decimal>("CostoUnitario"),
                    Stock = row.Field<int>("Existencias")
                }).ToList();

            dgProductos.DataSource = productos;
            dgProductos.Columns["Nombre"].Width = 300;
            dgProductos.Columns["Imagen"].Visible = false;
            dgProductos.Columns["Fotografia"].Width = 200;
        }
        #endregion
    }
}
