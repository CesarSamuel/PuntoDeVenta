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
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Almacen", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Agregar Receptor");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Agregar Emisor");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Clientes", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.tvBotnesMenu = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.pnPrincipal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbeUsuario = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
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
            treeNode8.ImageIndex = 1;
            treeNode8.Name = "ndAlmacen";
            treeNode8.Text = "Almacen";
            treeNode9.Name = "sndAddReceptor";
            treeNode9.Text = "Agregar Receptor";
            treeNode10.Name = "sndAddEmisor";
            treeNode10.Text = "Agregar Emisor";
            treeNode11.ImageIndex = 2;
            treeNode11.Name = "ndClientes";
            treeNode11.Text = "Clientes";
            this.tvBotnesMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode11});
            this.tvBotnesMenu.SelectedImageIndex = 0;
            this.tvBotnesMenu.Size = new System.Drawing.Size(152, 680);
            this.tvBotnesMenu.TabIndex = 0;
            this.tvBotnesMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ClicBotonNodo);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "users.png");
            this.imageList1.Images.SetKeyName(1, "almacen.png");
            this.imageList1.Images.SetKeyName(2, "clientes.png");
            this.imageList1.Images.SetKeyName(3, "adduser.png");
            this.imageList1.Images.SetKeyName(4, "delluser.png");
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1310, 719);
            this.tableLayoutPanel1.TabIndex = 2;
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
            // pnPrincipal
            // 
            this.pnPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPrincipal.Location = new System.Drawing.Point(161, 3);
            this.pnPrincipal.Name = "pnPrincipal";
            this.pnPrincipal.Size = new System.Drawing.Size(1146, 680);
            this.pnPrincipal.TabIndex = 1;
            this.pnPrincipal.Resize += new System.EventHandler(this.pnPrincipal_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCerrarSesion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 689);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 27);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbUsuario);
            this.panel2.Controls.Add(this.lbeUsuario);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(161, 689);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1146, 27);
            this.panel2.TabIndex = 3;
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
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(55, 8);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(0, 13);
            this.lbUsuario.TabIndex = 1;
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 719);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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