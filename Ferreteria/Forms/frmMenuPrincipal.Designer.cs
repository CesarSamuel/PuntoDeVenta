namespace Ferreteria.Forms
{
    partial class frmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Agregar Usuario");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Borrar Usuario");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Lista de usuarios");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Usuarios", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Agregar Producto");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Agregar Dept.");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Agregar Sucursal");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Lista productos");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Almacen", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Agregar Receptor");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Agregar Emisor");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Lista Receptores");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Clientes", new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode29,
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Punto de Venta");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Lista de Ventas");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Ventas", new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Caja");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Administración", new System.Windows.Forms.TreeNode[] {
            treeNode35});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.tvBotnesMenu = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnPrincipal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbeUsuario = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvBotnesMenu
            // 
            this.tvBotnesMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvBotnesMenu.ImageIndex = 0;
            this.tvBotnesMenu.ImageList = this.imageList1;
            this.tvBotnesMenu.Location = new System.Drawing.Point(3, 3);
            this.tvBotnesMenu.Name = "tvBotnesMenu";
            treeNode19.ImageIndex = 3;
            treeNode19.Name = "sndAddUser";
            treeNode19.Text = "Agregar Usuario";
            treeNode20.ImageIndex = 4;
            treeNode20.Name = "sndDelUser";
            treeNode20.Text = "Borrar Usuario";
            treeNode21.Name = "sndListaUsuarios";
            treeNode21.Text = "Lista de usuarios";
            treeNode22.Name = "ndUsuarios";
            treeNode22.Text = "Usuarios";
            treeNode23.Name = "sndAddProducto";
            treeNode23.Text = "Agregar Producto";
            treeNode24.Name = "sndAddDepartamento";
            treeNode24.Text = "Agregar Dept.";
            treeNode25.Name = "sndAddSucursal";
            treeNode25.Text = "Agregar Sucursal";
            treeNode26.ImageIndex = 4;
            treeNode26.Name = "sndListaProductos";
            treeNode26.Text = "Lista productos";
            treeNode27.ImageIndex = 1;
            treeNode27.Name = "ndAlmacen";
            treeNode27.Text = "Almacen";
            treeNode28.Name = "sndAddReceptor";
            treeNode28.Text = "Agregar Receptor";
            treeNode29.Name = "sndAddEmisor";
            treeNode29.Text = "Agregar Emisor";
            treeNode30.Name = "sndListaReceptores";
            treeNode30.Text = "Lista Receptores";
            treeNode31.ImageIndex = 2;
            treeNode31.Name = "ndClientes";
            treeNode31.Text = "Clientes";
            treeNode32.ImageIndex = 10;
            treeNode32.Name = "sndPuntoVenta";
            treeNode32.Text = "Punto de Venta";
            treeNode33.ImageIndex = 9;
            treeNode33.Name = "sndListaVenta";
            treeNode33.Text = "Lista de Ventas";
            treeNode34.ImageIndex = 8;
            treeNode34.Name = "ndVentas";
            treeNode34.Text = "Ventas";
            treeNode35.ImageIndex = 12;
            treeNode35.Name = "sndCaja";
            treeNode35.Text = "Caja";
            treeNode36.ImageIndex = 11;
            treeNode36.Name = "ndAdminitrativo";
            treeNode36.Text = "Administración";
            this.tvBotnesMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode27,
            treeNode31,
            treeNode34,
            treeNode36});
            this.tvBotnesMenu.SelectedImageIndex = 0;
            this.tvBotnesMenu.Size = new System.Drawing.Size(162, 680);
            this.tvBotnesMenu.TabIndex = 0;
            this.tvBotnesMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ClicBotonNodo);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "clientes.png");
            this.imageList1.Images.SetKeyName(1, "adduser.png");
            this.imageList1.Images.SetKeyName(2, "delluser.png");
            this.imageList1.Images.SetKeyName(3, "adduser.png");
            this.imageList1.Images.SetKeyName(4, "almacen.png");
            this.imageList1.Images.SetKeyName(5, "clientes.png");
            this.imageList1.Images.SetKeyName(6, "delluser.png");
            this.imageList1.Images.SetKeyName(7, "users.png");
            this.imageList1.Images.SetKeyName(8, "ventas.png");
            this.imageList1.Images.SetKeyName(9, "ListaVentas.png");
            this.imageList1.Images.SetKeyName(10, "puntodeventa.png");
            this.imageList1.Images.SetKeyName(11, "Administrativo.png");
            this.imageList1.Images.SetKeyName(12, "caja.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.06107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.93893F));
            this.tableLayoutPanel1.Controls.Add(this.tvBotnesMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnPrincipal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1399, 719);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pnPrincipal
            // 
            this.pnPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPrincipal.Location = new System.Drawing.Point(171, 3);
            this.pnPrincipal.Name = "pnPrincipal";
            this.pnPrincipal.Size = new System.Drawing.Size(1225, 680);
            this.pnPrincipal.TabIndex = 1;
            this.pnPrincipal.Resize += new System.EventHandler(this.pnPrincipal_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCerrarSesion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 689);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 27);
            this.panel1.TabIndex = 2;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 4);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(87, 23);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbUsuario);
            this.panel2.Controls.Add(this.lbeUsuario);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(171, 689);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1225, 27);
            this.panel2.TabIndex = 3;
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(55, 8);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(0, 13);
            this.lbUsuario.TabIndex = 1;
            // 
            // lbeUsuario
            // 
            this.lbeUsuario.AutoSize = true;
            this.lbeUsuario.Location = new System.Drawing.Point(3, 8);
            this.lbeUsuario.Name = "lbeUsuario";
            this.lbeUsuario.Size = new System.Drawing.Size(46, 13);
            this.lbeUsuario.TabIndex = 0;
            this.lbeUsuario.Text = "Usuario:";
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 719);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "max";
            this.Text = "Materiales Barsvs";
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvBotnesMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel pnPrincipal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbeUsuario;
    }
}