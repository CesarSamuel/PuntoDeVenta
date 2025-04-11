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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Agregar Usuario");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Borrar Usuario");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Lista de usuarios");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Usuarios", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Agregar Producto");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Agregar Dept.");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Agregar Sucursal");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Lista productos");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Almacen", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Agregar Receptor");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Agregar Emisor");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Lista Receptores");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Clientes", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Punto de Venta");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Lista de Ventas");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Ventas", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15});
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
            treeNode1.ImageIndex = 3;
            treeNode1.Name = "sndAddUser";
            treeNode1.Text = "Agregar Usuario";
            treeNode2.ImageIndex = 4;
            treeNode2.Name = "sndDelUser";
            treeNode2.Text = "Borrar Usuario";
            treeNode3.Name = "sndListaUsuarios";
            treeNode3.Text = "Lista de usuarios";
            treeNode4.Name = "ndUsuarios";
            treeNode4.Text = "Usuarios";
            treeNode5.Name = "sndAddProducto";
            treeNode5.Text = "Agregar Producto";
            treeNode6.Name = "sndAddDepartamento";
            treeNode6.Text = "Agregar Dept.";
            treeNode7.Name = "sndAddSucursal";
            treeNode7.Text = "Agregar Sucursal";
            treeNode8.ImageIndex = 4;
            treeNode8.Name = "sndListaProductos";
            treeNode8.Text = "Lista productos";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "ndAlmacen";
            treeNode9.Text = "Almacen";
            treeNode10.Name = "sndAddReceptor";
            treeNode10.Text = "Agregar Receptor";
            treeNode11.Name = "sndAddEmisor";
            treeNode11.Text = "Agregar Emisor";
            treeNode12.Name = "sndListaReceptores";
            treeNode12.Text = "Lista Receptores";
            treeNode13.ImageIndex = 2;
            treeNode13.Name = "ndClientes";
            treeNode13.Text = "Clientes";
            treeNode14.ImageIndex = 10;
            treeNode14.Name = "sndPuntoVenta";
            treeNode14.Text = "Punto de Venta";
            treeNode15.ImageIndex = 9;
            treeNode15.Name = "sndListaVenta";
            treeNode15.Text = "Lista de Ventas";
            treeNode16.ImageIndex = 8;
            treeNode16.Name = "ndVentas";
            treeNode16.Text = "Ventas";
            this.tvBotnesMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode9,
            treeNode13,
            treeNode16});
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
            this.btnCerrarSesion.Location = new System.Drawing.Point(42, 3);
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