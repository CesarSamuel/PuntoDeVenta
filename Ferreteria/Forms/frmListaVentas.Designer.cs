namespace Ferreteria.Forms
{
    partial class frmListaVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaVentas));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgDetalles = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFotografia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgVenta = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbBuscador = new System.Windows.Forms.Label();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.chbUltimosDias = new System.Windows.Forms.CheckBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.txtRfc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.chbFechas = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalles)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVenta)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.90234F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 321F));
            this.tableLayoutPanel1.Controls.Add(this.dgDetalles, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbProducto, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.16949F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.83051F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 664);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgDetalles
            // 
            this.dgDetalles.AllowUserToAddRows = false;
            this.dgDetalles.AllowUserToDeleteRows = false;
            this.dgDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colIdD,
            this.colFotografia,
            this.colCantidad,
            this.colPrecio,
            this.colImporte,
            this.colDepartamento});
            this.dgDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetalles.Location = new System.Drawing.Point(3, 373);
            this.dgDetalles.Name = "dgDetalles";
            this.dgDetalles.ReadOnly = true;
            this.dgDetalles.Size = new System.Drawing.Size(697, 288);
            this.dgDetalles.TabIndex = 1;
            this.dgDetalles.SelectionChanged += new System.EventHandler(this.dgDetalles_SelectionChanged);
            // 
            // colProducto
            // 
            this.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colIdD
            // 
            this.colIdD.HeaderText = "Id";
            this.colIdD.Name = "colIdD";
            this.colIdD.ReadOnly = true;
            this.colIdD.Visible = false;
            // 
            // colFotografia
            // 
            this.colFotografia.HeaderText = "Fotografia";
            this.colFotografia.Name = "colFotografia";
            this.colFotografia.ReadOnly = true;
            this.colFotografia.Visible = false;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colImporte
            // 
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            // 
            // colDepartamento
            // 
            this.colDepartamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDepartamento.HeaderText = "Departamento";
            this.colDepartamento.Name = "colDepartamento";
            this.colDepartamento.ReadOnly = true;
            this.colDepartamento.Width = 99;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.dgVenta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 290);
            this.panel1.TabIndex = 2;
            // 
            // dgVenta
            // 
            this.dgVenta.AllowUserToAddRows = false;
            this.dgVenta.AllowUserToDeleteRows = false;
            this.dgVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colEmisor,
            this.colReceptor,
            this.colVendedor,
            this.colTotal,
            this.colItems,
            this.colProductos,
            this.colId});
            this.dgVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVenta.Location = new System.Drawing.Point(0, 0);
            this.dgVenta.Name = "dgVenta";
            this.dgVenta.ReadOnly = true;
            this.dgVenta.Size = new System.Drawing.Size(1018, 290);
            this.dgVenta.TabIndex = 0;
            this.dgVenta.SelectionChanged += new System.EventHandler(this.dgVenta_SelectionChanged);
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 62;
            // 
            // colEmisor
            // 
            this.colEmisor.DataPropertyName = "Emisor";
            this.colEmisor.HeaderText = "Emisor";
            this.colEmisor.Name = "colEmisor";
            this.colEmisor.ReadOnly = true;
            this.colEmisor.Width = 63;
            // 
            // colReceptor
            // 
            this.colReceptor.DataPropertyName = "Receptor";
            this.colReceptor.HeaderText = "Receptor";
            this.colReceptor.Name = "colReceptor";
            this.colReceptor.ReadOnly = true;
            this.colReceptor.Width = 76;
            // 
            // colVendedor
            // 
            this.colVendedor.DataPropertyName = "Vendedor";
            this.colVendedor.HeaderText = "Vendedor";
            this.colVendedor.Name = "colVendedor";
            this.colVendedor.ReadOnly = true;
            this.colVendedor.Width = 78;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 56;
            // 
            // colItems
            // 
            this.colItems.DataPropertyName = "Items";
            this.colItems.HeaderText = "#";
            this.colItems.Name = "colItems";
            this.colItems.ReadOnly = true;
            this.colItems.Width = 39;
            // 
            // colProductos
            // 
            this.colProductos.DataPropertyName = "Productos";
            this.colProductos.HeaderText = "Productos";
            this.colProductos.Name = "colProductos";
            this.colProductos.ReadOnly = true;
            this.colProductos.Width = 80;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "VentaId";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 41;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.chbFechas);
            this.panel2.Controls.Add(this.txtEmpleado);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtCliente);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtRfc);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtpFechaInicio);
            this.panel2.Controls.Add(this.dtpFechaFin);
            this.panel2.Controls.Add(this.chbUltimosDias);
            this.panel2.Controls.Add(this.lbBuscador);
            this.panel2.Controls.Add(this.txtBuscador);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 68);
            this.panel2.TabIndex = 4;
            // 
            // lbBuscador
            // 
            this.lbBuscador.AutoSize = true;
            this.lbBuscador.Location = new System.Drawing.Point(6, 48);
            this.lbBuscador.Name = "lbBuscador";
            this.lbBuscador.Size = new System.Drawing.Size(55, 13);
            this.lbBuscador.TabIndex = 5;
            this.lbBuscador.Text = "Buscador:";
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(67, 45);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(315, 20);
            this.txtBuscador.TabIndex = 4;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // chbUltimosDias
            // 
            this.chbUltimosDias.AutoSize = true;
            this.chbUltimosDias.Checked = true;
            this.chbUltimosDias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUltimosDias.Location = new System.Drawing.Point(916, 44);
            this.chbUltimosDias.Name = "chbUltimosDias";
            this.chbUltimosDias.Size = new System.Drawing.Size(99, 17);
            this.chbUltimosDias.TabIndex = 6;
            this.chbUltimosDias.Text = "Utimos 30 Días";
            this.chbUltimosDias.UseVisualStyleBackColor = true;
            this.chbUltimosDias.CheckedChanged += new System.EventHandler(this.chbUltimosDias_CheckedChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(703, 45);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 7;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(703, 11);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fecha Fin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(629, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha Inicio:";
            // 
            // pbProducto
            // 
            this.pbProducto.BackgroundImage = global::Ferreteria.Properties.Resources.LogoRecortado;
            this.pbProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProducto.Location = new System.Drawing.Point(706, 373);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(315, 288);
            this.pbProducto.TabIndex = 3;
            this.pbProducto.TabStop = false;
            // 
            // txtRfc
            // 
            this.txtRfc.Location = new System.Drawing.Point(67, 14);
            this.txtRfc.Name = "txtRfc";
            this.txtRfc.Size = new System.Drawing.Size(140, 20);
            this.txtRfc.TabIndex = 11;
            this.txtRfc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRfc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRfc_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "RFC:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(213, 14);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(410, 20);
            this.txtCliente.TabIndex = 13;
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(548, 43);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Empleado:";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(442, 44);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(100, 20);
            this.txtEmpleado.TabIndex = 16;
            this.txtEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbFechas
            // 
            this.chbFechas.AutoSize = true;
            this.chbFechas.Checked = true;
            this.chbFechas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbFechas.Location = new System.Drawing.Point(916, 11);
            this.chbFechas.Name = "chbFechas";
            this.chbFechas.Size = new System.Drawing.Size(86, 17);
            this.chbFechas.TabIndex = 17;
            this.chbFechas.Text = "Usar Fechas";
            this.chbFechas.UseVisualStyleBackColor = true;
            this.chbFechas.CheckedChanged += new System.EventHandler(this.chbFechas_CheckedChanged);
            // 
            // frmListaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 664);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaVentas";
            this.Text = "Lista de ventas";
            this.Load += new System.EventHandler(this.frmListaVentas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalles)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVenta)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgVenta;
        private System.Windows.Forms.DataGridView dgDetalles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFotografia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartamento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbBuscador;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.CheckBox chbUltimosDias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRfc;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.CheckBox chbFechas;
    }
}