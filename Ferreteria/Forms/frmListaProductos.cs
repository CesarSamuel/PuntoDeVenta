using Ferreteria.Conexion;
using Ferreteria.Entidades;
using Ferreteria.Utilidades;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.Forms
{
    public partial class frmListaProductos : Form
    {
        #region Variables Globales
        utilidades util = new utilidades();
        Imagenes imgz = new Imagenes();
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
            llenarGridProductos();
            dgProductos.Focus();
        }
        #endregion

        #region llenado de Grid de productos 
        public void llenarGridProductos()
        {
            DataTable dtProductos = util.EjecutarSp("sp_ConsultarProductos");
            List<ProductoVista> productos = dtProductos.AsEnumerable()
                .Select(row => new ProductoVista
                {
                    Imagen = row.Field<byte[]>("Fotografia"),
                    Nombre = row.Field<string>("Nombre"),
                    Precio = row.Field<decimal>("CostoUnitario"),
                    Stock = row.Field<int>("Existencias"),
                    Descripcion = row.Field<string>("DescripcionCorta"),
                    CodigoDeBarras = row.Field<string>("CodigoDeBarras"),
                    Usuario = row.Field<string>("NombreUsuario"),
                    Departamento = row.Field<string>("NombreDepartamento"),
                    Sucursal = row.Field<string>("NombreSucursal"),
                    DescripcionLarga = row.Field<string>("DescripcionLarga"), 
                    id = row.Field<int>("Id")
                }).ToList();
            dgProductos.AutoGenerateColumns = false;
            dgProductos.DataSource = productos;
            datosOriginales = ConvertListToDataTable(productos);

            dgProductos.Columns["colFotografia"].DataPropertyName = "Imagen"; // Nombre de la propiedad en ProductoVista
            dgProductos.Columns["colNombre"].DataPropertyName = "Nombre";
            dgProductos.Columns["colDecCorta"].DataPropertyName = "Descripcion";
            dgProductos.Columns["colCostoUnitario"].DataPropertyName = "Precio";
            dgProductos.Columns["colExistencias"].DataPropertyName = "Stock";
            dgProductos.Columns["colImagen"].DataPropertyName = "Fotografia";
            dgProductos.Columns["colCodBarras"].DataPropertyName = "CodigoDeBarras";
            dgProductos.Columns["colUsuario"].DataPropertyName = "Usuario";
            dgProductos.Columns["colDepartamento"].DataPropertyName = "Departamento";
            dgProductos.Columns["colSucursal"].DataPropertyName = "Sucursal";
            dgProductos.Columns["colDescLarga"].DataPropertyName = "DescripcionLarga";
            dgProductos.Columns["colId"].DataPropertyName = "id";

            dgProductos.Columns["colCostoUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProductos.Columns["colExistencias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProductos.Columns["colUsuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
        }

        public DataTable ConvertListToDataTable(List<ProductoVista> productos)
        {
            DataTable dt = new DataTable();

            // Obtener las propiedades de la clase ProductoVista
            PropertyInfo[] properties = typeof(ProductoVista).GetProperties();

            // Crear columnas en el DataTable según las propiedades
            foreach (PropertyInfo property in properties)
            {
                dt.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Llenar el DataTable con los valores de la lista
            foreach (ProductoVista producto in productos)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(producto, null) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return dt;
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
                        pbImagenProducto.BackgroundImage = imagen;
                        pbImagenProducto.BackgroundImageLayout = ImageLayout.Stretch;
                        txtDescLarga.Text = filaSeleccionada.Cells["colDescLarga"].Value.ToString();
                        // Liberar la imagen anterior si existe
                        if (pbImagenProducto.Tag is Image oldImage)
                        {
                            oldImage.Dispose();
                        }
                        pbImagenProducto.Tag = imagen;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                        pbImagenProducto.BackgroundImage = Properties.Resources.LogoRecortado;
                    }
                }
                else
                {
                    pbImagenProducto.BackgroundImage = Properties.Resources.LogoRecortado;
                }
            }
        }

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

            dgProductos.DataSource = vista;
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

        private void dgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que el clic no fue en los encabezados de columna/fila
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow fila = dgProductos.Rows[e.RowIndex];

                string id = fila.Cells[15].Value?.ToString();

                DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea modificar este Producto?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Código si el usuario confirma
                    ModificarProducto(id);
                }
                else
                {
                    // Código si el usuario cancela
                    MessageBox.Show("Operación cancelada");
                }
            }
        }

        #region Modificacion de usuario
        public void ModificarProducto(string idProdcuto)
        {
            frmAddProducto frmProducto = new frmAddProducto(IdUsuario,int.Parse(idProdcuto));
            frmProducto.FormClosed += (sender, e) =>
            {
                llenarGridProductos();
            };
            frmProducto.ShowDialog();
        }
        #endregion
    }
}
