using Ferreteria.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Ferreteria
{
    public partial class Form1 : Form
    {
        public string tipoUsuario, Usuario;
        public int IdUsuario;
        public Form1()
        {
            InitializeComponent();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            validarUsuario();
        }

        public void Iniciar()
        {
            if (validarUsuario())
            {
                frmMenuPrincipal frmMenu = new frmMenuPrincipal(tipoUsuario, Usuario, IdUsuario);
                frmMenu.FormClosed += (s, args) => this.Close();
                this.Hide();
                frmMenu.Show();
            }
        }

        public bool validarUsuario()
        {
            // string.IsNullOrEmpty(): Verificar si es nulo o vacío (forma combinada)
            // IsNullOrWhiteSpace: Verificar si es nulo, vacío o solo contiene espacios en blanco
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == string.Empty || txtUsuario.Text == "")
            {
                MessageBox.Show("Favor de agregar un usuario", "Error en usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtContra.Text) || string.IsNullOrWhiteSpace(txtContra.Text) || txtContra.Text == string.Empty || txtContra.Text == "")
            {
                MessageBox.Show("Favor de agregar una contraseña", "Error en contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                var resultado = consultarUsuario(txtUsuario.Text, txtContra.Text);
                if(resultado.codigoResultado == 0)
                {
                    MessageBox.Show("Usuario o contraseña incorrectas", "Error de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    tipoUsuario = resultado.tipoUsuarioBD;
                    Usuario = resultado.Usuario;
                    return true;
                }
            }
            
        }

        public (int codigoResultado, string mensajeResultado, string tipoUsuarioBD, string Usuario) consultarUsuario(string usuario, string contra)
        {
            Conexion.Conexion db = new Conexion.Conexion();
            // Variables para almacenar los resultados
            int codigoResultado = 0;
            string mensajeResultado = "UsuarioInvalido";
            string tipoUsuario = "", Usuario = ""; 

            using (SqlConnection connection = new SqlConnection(db.connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_ValidarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        command.Parameters.AddWithValue("@NombreUsuario", usuario);
                        command.Parameters.AddWithValue("@Contrasena", contra);

                        // Ejecutar el SP y leer los resultados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Si hay resultados
                            {
                                codigoResultado = reader.GetInt32(0); // Primera columna (Codigo)
                                mensajeResultado = reader.GetString(1); // Segunda columna (Mensaje)
                                tipoUsuario = reader.GetString(2);//Agregamos la columna de tipo de usuario 
                                Usuario = reader.GetString(3);//Agregamos la columna de nombre de  usuario 
                                IdUsuario = reader.GetInt32(4);//Agregamos la columna de idUsuario 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    mensajeResultado = $"Error al validar usuario: {ex.Message}";
                    // Puedes loggear el error aquí si lo necesitas
                }
            }

            return (codigoResultado, mensajeResultado, tipoUsuario, Usuario);
        }

        private void Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Iniciar();
            }
        }

        private void ingresarContra(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtContra.Focus();
            }

        }
    }
}
