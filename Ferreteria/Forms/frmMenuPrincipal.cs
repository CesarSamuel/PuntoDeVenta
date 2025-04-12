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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ferreteria.Forms
{
    public partial class frmMenuPrincipal : Form
    {
        public string tipoUser, Usuario;
        public int IdUsuario;
        utilidades util = new utilidades();
        //diccionario de formularios para abrirlos según el nodo seleccionado
        private readonly Dictionary<string, Func<Form>> _formularios = new Dictionary<string, Func<Form>>();
        // Diccionario para guardar nodos ocultos y sus padres
        Dictionary<TreeNode, TreeNode> nodosOcultos = new Dictionary<TreeNode, TreeNode>();

        //Método para inicializar el diccionario (llamar en el constructor o cuando tengas los parámetros)
        private void InicializarDiccionarioFormularios()
        {
            // Limpiar si ya tenía valores
            _formularios.Clear();

            // Llenar el diccionario con las opciones
            _formularios.Add("sndAddUser", () => new frmAddUser(tipoUser));
            _formularios.Add("sndAddProducto", () => new frmAddProducto(IdUsuario));
            _formularios.Add("sndListaUsuarios", () => new frmListaUsuarios());
            _formularios.Add("sndListaProductos", () => new frmListaProductos(IdUsuario));
            _formularios.Add("sndListaVenta", () => new frmListaVentas());
            _formularios.Add("sndPuntoVenta", () => new frmVenta(IdUsuario));
            _formularios.Add("sndListaReceptores", () => new frmListaReceptores());
            _formularios.Add("sndCaja", () => new frmCaja(1,IdUsuario));

            // Agregar más formularios según sea necesario
        }

        private void ClicBotonNodo(object sender, TreeNodeMouseClickEventArgs e)
        {
            // e.Node contiene el nodo que recibió el doble clic
            TreeNode nodoSeleccionado = e.Node;
            bool VentanaNueva = false;
            // Verificar si Control está presionado
            if (Control.ModifierKeys == Keys.Control) { VentanaNueva = true; }

            // Puedes acceder a sus propiedades
            string valorNodo = nodoSeleccionado.Name; // Si asignaste un nombre

            // Uso simplificado del switch original
            switch (valorNodo)
            {
                case "sndAddUser":
                case "sndAddProducto":
                case "sndListaUsuarios":
                case "sndListaProductos":
                case "sndListaVenta":
                case "sndListaReceptores":
                case "sndCaja":
                    AbrirFormularioSegunNodo(valorNodo, VentanaNueva);
                    break;
                case "sndPuntoVenta":
                    if (ValidarCaja())
                    {
                        AbrirFormularioSegunNodo(valorNodo, VentanaNueva);
                    }
                    else
                    {
                        if (AbrirCaja())
                        {
                            AbrirFormularioSegunNodo(valorNodo, VentanaNueva);
                        }
                    }
                break;
            }
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

        public bool AbrirCaja()
        {
            if ((tipoUser == "Administrador") || (tipoUser == "Root"))
            {
                frmCaja Caja = new frmCaja(1, IdUsuario);
                Caja.ShowDialog();
                if (ValidarCaja())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo abrir la caja, favor de verificar", "Error al abrir caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No tienes permisos para abrir la caja\n Por favor solicita a un Administrador Abrir Caja", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public frmMenuPrincipal(string tipoUser, string Usuario, int idUsuario)
        {
            InitializeComponent();
            this.tipoUser = tipoUser;
            this.Usuario = Usuario;
            this.IdUsuario = idUsuario;
        }

        public void abrirFormulario(Form formularioEnviado)
        {
            while(pnPrincipal.Controls.Count > 0)
            {
                pnPrincipal.Controls.RemoveAt(0);
            }

            Form formularioHijo = formularioEnviado; // El formulario que nos mandaron lo guardamos en la variable
            formularioEnviado.TopLevel = false; // para quitar la propiedad 
           
            formularioHijo.FormBorderStyle = FormBorderStyle.None; // para quitar los bordes 

            // Configuramos el panel para permitir scroll
            pnPrincipal.AutoScroll = true;

            // No usamos DockStyle.Fill para permitir el centrado
            formularioHijo.Dock = DockStyle.None;

            // Centramos el formulario
            formularioHijo.Location = new Point(
                Math.Max((pnPrincipal.ClientSize.Width - formularioHijo.Width) / 2, 0),
                Math.Max((pnPrincipal.ClientSize.Height - formularioHijo.Height) / 2, 0)
            );

            this.Text = formularioHijo.Text; //le pasamos el titulo del formulario hijo al formulario padre 
            pnPrincipal.Controls.Add(formularioHijo);
            formularioHijo.Show();
        }



        // Método unificado para abrir formularios
        private void AbrirFormularioSegunNodo(string valorNodo, bool VentanaNueva)
        {
            if (_formularios.TryGetValue(valorNodo, out var crearFormulario))
            {
                var formulario = crearFormulario();

                if (VentanaNueva)
                {
                    formulario.Show();
                }
                else
                {
                    abrirFormulario(formulario);
                }
            }
        }

        private void pnPrincipal_Resize(object sender, EventArgs e)
        {

            if (pnPrincipal.Controls.Count == 0) return;

            Form formularioHijo = pnPrincipal.Controls[0] as Form;
            if (formularioHijo == null) return;

            // Sincronizar el estado de la ventana
            SynchronizeWindowState(formularioHijo);

            // Asegurar que el scroll se actualice
            pnPrincipal.PerformLayout();
        }

        private void SynchronizeWindowState(Form childForm)
        {
            if (childForm.WindowState == FormWindowState.Maximized)
            {
                // Configurar el formulario hijo para llenar el panel
                childForm.WindowState = FormWindowState.Normal; // Importante resetear primero
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.TopLevel = false;
                childForm.Dock = DockStyle.Fill;
                childForm.Size = pnPrincipal.ClientSize;
                childForm.Location = Point.Empty;
            }
            else
            {
                // Restaurar configuración normal
                childForm.FormBorderStyle = FormBorderStyle.Sizable;
                childForm.Dock = DockStyle.None;
                childForm.WindowState = FormWindowState.Normal;

                // Centrar el formulario hijo
                childForm.Location = new Point(
                    Math.Max((pnPrincipal.ClientSize.Width - childForm.Width) / 2, 0),
                    Math.Max((pnPrincipal.ClientSize.Height - childForm.Height) / 2, 0)
                );
            }
        }

        // También llama a este método cuando cargas el formulario hijo por primera vez
        private void LoadChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            pnPrincipal.Controls.Clear();
            pnPrincipal.Controls.Add(childForm);
            SynchronizeWindowState(childForm);
            childForm.Show();
        }

        // Ocultar nodo por nombre
        public void OcultarNodoPorNombre(string nombreNodo)
        {
            TreeNode nodo = BuscarNodoPorNombre(tvBotnesMenu.Nodes, nombreNodo);
            if (nodo != null)
            {
                if (nodo.Parent != null)
                {
                    nodosOcultos[nodo] = nodo.Parent;
                    nodo.Parent.Nodes.Remove(nodo);
                }
                else
                {
                    nodosOcultos[nodo] = null;
                    tvBotnesMenu.Nodes.Remove(nodo);
                }
            }
        }

        // Mostrar nodo previamente oculto
        public void MostrarNodoOculto(string nombreNodo)
        {
            var nodo = nodosOcultos.Keys.FirstOrDefault(n => n.Text == nombreNodo);
            if (nodo != null)
            {
                if (nodosOcultos[nodo] != null)
                    nodosOcultos[nodo].Nodes.Add(nodo);
                else
                    tvBotnesMenu.Nodes.Add(nodo);

                nodosOcultos.Remove(nodo);
            }
        }

        // Método auxiliar para buscar nodo por nombre
        private TreeNode BuscarNodoPorNombre(TreeNodeCollection nodos, string nombre)
        {
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Text == nombre)
                    return nodo;

                var encontrado = BuscarNodoPorNombre(nodo.Nodes, nombre);
                if (encontrado != null)
                    return encontrado;
            }
            return null;
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            ValidarNodos();
            lbUsuario.Text = Usuario;
            InicializarDiccionarioFormularios();
        }

        public void ValidarNodos()
        {
            if((tipoUser != "Administrador") && (tipoUser != "Root"))
            {
                OcultarNodoPorNombre("Administración");
            }
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 frmLogin = new Form1();
            frmLogin.FormClosed += (s, args) => this.Close();
            this.Hide();
            frmLogin.Show();
        }
    }
}
