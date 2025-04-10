namespace Ferreteria.Forms
{
    partial class frmListaProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaProductos));
            this.dgProductos = new System.Windows.Forms.DataGridView();
            this.pbImagenProducto = new System.Windows.Forms.PictureBox();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.lbBuscador = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDescLarga = new System.Windows.Forms.TextBox();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDecCorta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExistencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFotografia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescLarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProductos
            // 
            this.dgProductos.AllowUserToAddRows = false;
            this.dgProductos.AllowUserToDeleteRows = false;
            this.dgProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colDecCorta,
            this.colCostoUnitario,
            this.colExistencias,
            this.colCodBarras,
            this.colUsuario,
            this.colDepartamento,
            this.colSucursal,
            this.colFechaCreacion,
            this.colIdUsuario,
            this.colIdDepartamento,
            this.colIdSucursal,
            this.colFotografia,
            this.colImagen,
            this.colDescLarga,
            this.colId});
            this.dgProductos.Location = new System.Drawing.Point(12, 161);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            this.dgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductos.Size = new System.Drawing.Size(1172, 471);
            this.dgProductos.TabIndex = 0;
            this.dgProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductos_CellDoubleClick);
            this.dgProductos.SelectionChanged += new System.EventHandler(this.dgProductos_SelectionChanged);
            // 
            // pbImagenProducto
            // 
            this.pbImagenProducto.BackgroundImage = global::Ferreteria.Properties.Resources.LogoRecortado;
            this.pbImagenProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImagenProducto.Location = new System.Drawing.Point(984, 12);
            this.pbImagenProducto.Name = "pbImagenProducto";
            this.pbImagenProducto.Size = new System.Drawing.Size(200, 143);
            this.pbImagenProducto.TabIndex = 1;
            this.pbImagenProducto.TabStop = false;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(73, 135);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(414, 20);
            this.txtBuscador.TabIndex = 2;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // lbBuscador
            // 
            this.lbBuscador.AutoSize = true;
            this.lbBuscador.Location = new System.Drawing.Point(12, 138);
            this.lbBuscador.Name = "lbBuscador";
            this.lbBuscador.Size = new System.Drawing.Size(55, 13);
            this.lbBuscador.TabIndex = 3;
            this.lbBuscador.Text = "Buscador:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::Ferreteria.Properties.Resources.Buscador;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(493, 135);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 20);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtDescLarga
            // 
            this.txtDescLarga.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescLarga.Location = new System.Drawing.Point(524, 82);
            this.txtDescLarga.Multiline = true;
            this.txtDescLarga.Name = "txtDescLarga";
            this.txtDescLarga.Size = new System.Drawing.Size(454, 69);
            this.txtDescLarga.TabIndex = 5;
            // 
            // colNombre
            // 
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 69;
            // 
            // colDecCorta
            // 
            this.colDecCorta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDecCorta.HeaderText = "Descripcion";
            this.colDecCorta.Name = "colDecCorta";
            this.colDecCorta.ReadOnly = true;
            // 
            // colCostoUnitario
            // 
            this.colCostoUnitario.HeaderText = "Costo";
            this.colCostoUnitario.Name = "colCostoUnitario";
            this.colCostoUnitario.ReadOnly = true;
            this.colCostoUnitario.Width = 59;
            // 
            // colExistencias
            // 
            this.colExistencias.HeaderText = "Existencias";
            this.colExistencias.Name = "colExistencias";
            this.colExistencias.ReadOnly = true;
            this.colExistencias.Width = 85;
            // 
            // colCodBarras
            // 
            this.colCodBarras.HeaderText = "Codigo";
            this.colCodBarras.Name = "colCodBarras";
            this.colCodBarras.ReadOnly = true;
            this.colCodBarras.Width = 65;
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            this.colUsuario.Width = 68;
            // 
            // colDepartamento
            // 
            this.colDepartamento.HeaderText = "Departamento";
            this.colDepartamento.Name = "colDepartamento";
            this.colDepartamento.ReadOnly = true;
            this.colDepartamento.Width = 99;
            // 
            // colSucursal
            // 
            this.colSucursal.HeaderText = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.ReadOnly = true;
            this.colSucursal.Width = 73;
            // 
            // colFechaCreacion
            // 
            this.colFechaCreacion.HeaderText = "FechaCreacion";
            this.colFechaCreacion.Name = "colFechaCreacion";
            this.colFechaCreacion.ReadOnly = true;
            this.colFechaCreacion.Visible = false;
            this.colFechaCreacion.Width = 104;
            // 
            // colIdUsuario
            // 
            this.colIdUsuario.HeaderText = "IdUsuario";
            this.colIdUsuario.Name = "colIdUsuario";
            this.colIdUsuario.ReadOnly = true;
            this.colIdUsuario.Visible = false;
            this.colIdUsuario.Width = 77;
            // 
            // colIdDepartamento
            // 
            this.colIdDepartamento.HeaderText = "IdDepartamento";
            this.colIdDepartamento.Name = "colIdDepartamento";
            this.colIdDepartamento.ReadOnly = true;
            this.colIdDepartamento.Visible = false;
            this.colIdDepartamento.Width = 108;
            // 
            // colIdSucursal
            // 
            this.colIdSucursal.HeaderText = "IdSucursal";
            this.colIdSucursal.Name = "colIdSucursal";
            this.colIdSucursal.ReadOnly = true;
            this.colIdSucursal.Visible = false;
            this.colIdSucursal.Width = 82;
            // 
            // colFotografia
            // 
            this.colFotografia.HeaderText = "Fotografia";
            this.colFotografia.Name = "colFotografia";
            this.colFotografia.ReadOnly = true;
            this.colFotografia.Visible = false;
            this.colFotografia.Width = 79;
            // 
            // colImagen
            // 
            this.colImagen.HeaderText = "Imagen";
            this.colImagen.Name = "colImagen";
            this.colImagen.ReadOnly = true;
            this.colImagen.Visible = false;
            this.colImagen.Width = 67;
            // 
            // colDescLarga
            // 
            this.colDescLarga.HeaderText = "Descripcion Larga";
            this.colDescLarga.Name = "colDescLarga";
            this.colDescLarga.ReadOnly = true;
            this.colDescLarga.Visible = false;
            this.colDescLarga.Width = 118;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 41;
            // 
            // frmListaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 644);
            this.Controls.Add(this.txtDescLarga);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lbBuscador);
            this.Controls.Add(this.txtBuscador);
            this.Controls.Add(this.pbImagenProducto);
            this.Controls.Add(this.dgProductos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaProductos";
            this.Text = "Lista de Productos";
            this.Load += new System.EventHandler(this.frmListaProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProductos;
        private System.Windows.Forms.PictureBox pbImagenProducto;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.Label lbBuscador;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDescLarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDecCorta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExistencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFotografia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescLarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
    }
}