namespace Ferreteria.Forms
{
    partial class frmListaReceptores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaReceptores));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgListaClientes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRfc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResidenciaFiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsoCfdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaClientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgListaClientes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.30055F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.69946F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(948, 549);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgListaClientes
            // 
            this.dgListaClientes.AllowUserToAddRows = false;
            this.dgListaClientes.AllowUserToDeleteRows = false;
            this.dgListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListaClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colRfc,
            this.colRazonSocial,
            this.colResidenciaFiscal,
            this.colDireccion,
            this.colUsoCfdi});
            this.dgListaClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListaClientes.Location = new System.Drawing.Point(3, 87);
            this.dgListaClientes.Name = "dgListaClientes";
            this.dgListaClientes.ReadOnly = true;
            this.dgListaClientes.Size = new System.Drawing.Size(942, 459);
            this.dgListaClientes.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtBuscador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 78);
            this.panel1.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::Ferreteria.Properties.Resources.Buscador;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(915, 48);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(22, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(594, 48);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(315, 20);
            this.txtBuscador.TabIndex = 0;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colRfc
            // 
            this.colRfc.DataPropertyName = "RFC";
            this.colRfc.HeaderText = "RFC";
            this.colRfc.Name = "colRfc";
            this.colRfc.ReadOnly = true;
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRazonSocial.DataPropertyName = "RazonSocial";
            this.colRazonSocial.HeaderText = "Razon Social";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.ReadOnly = true;
            // 
            // colResidenciaFiscal
            // 
            this.colResidenciaFiscal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colResidenciaFiscal.DataPropertyName = "ResidenciaFiscal";
            this.colResidenciaFiscal.HeaderText = "Residencia Fiscal";
            this.colResidenciaFiscal.Name = "colResidenciaFiscal";
            this.colResidenciaFiscal.ReadOnly = true;
            this.colResidenciaFiscal.Width = 106;
            // 
            // colDireccion
            // 
            this.colDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDireccion.DataPropertyName = "Direccion";
            this.colDireccion.HeaderText = "Direccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.ReadOnly = true;
            // 
            // colUsoCfdi
            // 
            this.colUsoCfdi.DataPropertyName = "UsoCFDI";
            this.colUsoCfdi.HeaderText = "Uso CFDI";
            this.colUsoCfdi.Name = "colUsoCfdi";
            this.colUsoCfdi.ReadOnly = true;
            // 
            // frmListaReceptores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaReceptores";
            this.Text = "Lista de Clientes";
            this.Load += new System.EventHandler(this.frmListaReceptores_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgListaClientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgListaClientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRfc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResidenciaFiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsoCfdi;
    }
}