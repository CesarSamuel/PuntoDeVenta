using Ferreteria.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ferreteria.Forms
{
    public partial class frmAddUser : Form
    {
        public string tipoUsuaio, idUsuario;
        Conexion.Conexion db = new Conexion.Conexion();
        DataTable ParametrosTabla = new DataTable();
        utilidades util = new utilidades();
        public frmAddUser(string tipoUsuaio, string idUsuario = "")
        {
            InitializeComponent();
            this.tipoUsuaio = tipoUsuaio;
            this.idUsuario = idUsuario;
        }

        public void cboTipoUsuarioLlenar()
        {
            string[] TiposUsuarios = { "Usuario", "Vendedor" };
            List<string> lista = new List<string>(TiposUsuarios);
            
            switch (tipoUsuaio) {
                case "Root":
                    lista.Add("Administrador");
                    lista.Add("Root");
                    break;
                case "Administrador":
                    lista.Add("Administrador");
                    break;
            }

            // Limpiar items existentes
            cboTipoUsuario.Items.Clear();

            // Añadir todos los elementos de la lista
            cboTipoUsuario.Items.AddRange(lista.ToArray());
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            cboTipoUsuarioLlenar();
            ParametrosTabla.Columns.Add("Parametro", typeof(string));
            ParametrosTabla.Columns.Add("Valor", typeof(object));
            if (idUsuario != "")
            {
                // Cargar datos del usuario
                consultarUsuario(idUsuario);
                btnEliminar.Visible = true;
            }
               
        }

        public void GrabarUsuario()
        {
            if (ValidarDatosNewUser())
            {
                string Respues = ValidarExistenciaUsuario();
                if (Respues == "Disponible")
                {
                    if (txtPass.Text == txtConfirPass.Text)
                    {
                        if (insertarUsuario() == "Insert Correcto")
                        {
                            MessageBox.Show("Usuario Creado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Error Contraseñas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de usuario ya utilizado", "Usuario en uso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ModificarUsuario()
        {
            if (ValidarDatosNewUser())
            {
                if (txtPass.Text == txtConfirPass.Text)
                {
                    
                    DataTable resultado = util.EjecutarSp("sp_ModificarUsuario",
                        new Dictionary<string, object>
                        {
                            ["@Usuario"] = txtUsuario.Text,
                            ["@Contraseña"] = txtPass.Text,
                            ["@TipoUsuario"] = cboTipoUsuario.Text,
                            ["@NombreUsuario"] = txtNombreUsuario.Text,
                            ["numero"] = idUsuario
                        });
                    if (resultado.Rows[0][0].ToString() == "Update Correcto")
                    {
                        MessageBox.Show("Usuario Modificado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error Contraseñas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(idUsuario == "")
            {
                GrabarUsuario();
            }
            else
            {
                ModificarUsuario();
            }
        }

        public bool ValidarDatosNewUser()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == string.Empty || txtUsuario.Text == "")
            {
                MessageBox.Show("Favor de agregar un usuario", "Error en Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }else if (string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || txtNombreUsuario.Text == string.Empty || txtNombreUsuario.Text == "")
            {
                MessageBox.Show("Favor de agregar nombre de usuario", "Error en Nombre Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrWhiteSpace(txtPass.Text) || txtPass.Text == string.Empty || txtPass.Text == "")
            {
                MessageBox.Show("Favor de agrega Una contraseña", "Error en Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtConfirPass.Text) || string.IsNullOrWhiteSpace(txtConfirPass.Text) || txtConfirPass.Text == string.Empty || txtConfirPass.Text == "")
            {
                MessageBox.Show("Favor de agrega Una confirmacion de contraseña", "Error en Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(cboTipoUsuario.Text) || string.IsNullOrWhiteSpace(cboTipoUsuario.Text) || cboTipoUsuario.Text == string.Empty || cboTipoUsuario.Text == "")
            {
                MessageBox.Show("Favor de agrega Seleccionar un tipo de usuario", "Problemas en el tipo de usaurio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        public string ValidarExistenciaUsuario()
        {
            string Validador = "";
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_ValidarExistenciaUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        command.Parameters.AddWithValue("@NombreUSuario", txtUsuario.Text);

                        // Ejecutar el SP y leer los resultados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Si hay resultados
                            {
                                Validador = reader.GetString(0); // Primera columna (Codigo)
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Validador = $"Error al validar usuario: {ex.Message}";
                }
            }
            return Validador;
        }

        public string insertarUsuario()
        {
            string respuesta = "";
            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_InsertarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        command.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                        command.Parameters.AddWithValue("@Contraseña", txtPass.Text);
                        command.Parameters.AddWithValue("@TipoUsuario", cboTipoUsuario.Text);
                        command.Parameters.AddWithValue("@NombreUsuario", txtNombreUsuario.Text);
                        command.Parameters.AddWithValue("@numero", 1);

                        // Ejecutar el SP y leer los resultados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Si hay resultados
                            {
                                respuesta = reader.GetString(0); // Primera columna (Respuesta)
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = $"Error al validar usuario: {ex.Message}";
                }
            }
            return respuesta;
        }

        public void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtConfirPass.Text = "";
            cboTipoUsuario.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea Eliminar este Usuario?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Código si el usuario confirma
                EliminarUsuario();
            }
            else
            {
                // Código si el usuario cancela
                MessageBox.Show("Operación cancelada");
            }
        }

        #region Consultar Datos de usuario
        public void consultarUsuario(string id)
        {
            DataTable resultado = util.EjecutarSp("sp_ConsultarUsuario",
                new Dictionary<string, object>
                {
                    ["@idUsuario"] = id
                });
            // Asumiendo que tienes un DataTable llamado 'miDataTable'
            foreach (DataRow fila in resultado.Rows)
            {
                // Obtener valores por nombre de columna (recomendado)
                txtUsuario.Text = fila["NombreUsuario"].ToString();
                txtNombreUsuario.Text = fila["Usuario"].ToString();
                txtPass.Text = fila["Contrasena"].ToString();
                txtConfirPass.Text = fila["Contrasena"].ToString();
                // Para ComboBox con DataSource
                var item = cboTipoUsuario.Items.Cast<object>().FirstOrDefault(x => x.ToString() == fila["tipoUsuario"].ToString());

                if (item != null)
                {
                    cboTipoUsuario.SelectedItem = item;
                }
            }
        }
        #endregion

        #region Eliminar Usuario
        public void EliminarUsuario()
        {
            DataTable resultado = util.EjecutarSp("sp_EliminarUsuario",
                        new Dictionary<string, object>
                        {
                            ["numero"] = idUsuario
                        });
            if (resultado.Rows[0][0].ToString() == "Eliminacion Correcta")
            {
                MessageBox.Show("Usuario Eliminado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        #endregion
    }
}
