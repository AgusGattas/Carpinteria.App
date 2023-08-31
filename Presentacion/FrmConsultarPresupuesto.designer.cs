namespace CarpinteriaApp_1w3.Presentacion
{
    partial class FrmConsultarPresupuesto
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
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPresupuestos = new System.Windows.Forms.DataGridView();
            this.ColNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.btnConsultar);
            this.gbFiltros.Controls.Add(this.txtCliente);
            this.gbFiltros.Controls.Add(this.label3);
            this.gbFiltros.Controls.Add(this.dtpHasta);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.dtpDesde);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(687, 164);
            this.gbFiltros.TabIndex = 7;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(586, 96);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(104, 99);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(336, 20);
            this.txtCliente.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cliente";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(461, 60);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha Hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(103, 60);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Fecha Desde";
            // 
            // dgvPresupuestos
            // 
            this.dgvPresupuestos.AllowUserToAddRows = false;
            this.dgvPresupuestos.AllowUserToDeleteRows = false;
            this.dgvPresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNro,
            this.ColFecha,
            this.ColCliente,
            this.ColTotal,
            this.ColAcciones});
            this.dgvPresupuestos.Location = new System.Drawing.Point(41, 151);
            this.dgvPresupuestos.Name = "dgvPresupuestos";
            this.dgvPresupuestos.ReadOnly = true;
            this.dgvPresupuestos.RowHeadersVisible = false;
            this.dgvPresupuestos.Size = new System.Drawing.Size(704, 239);
            this.dgvPresupuestos.TabIndex = 8;
            // 
            // ColNro
            // 
            this.ColNro.HeaderText = "Presupuesto N";
            this.ColNro.Name = "ColNro";
            this.ColNro.ReadOnly = true;
            // 
            // ColFecha
            // 
            this.ColFecha.HeaderText = "Fecha";
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.ReadOnly = true;
            // 
            // ColCliente
            // 
            this.ColCliente.HeaderText = "Cliente";
            this.ColCliente.Name = "ColCliente";
            this.ColCliente.ReadOnly = true;
            this.ColCliente.Width = 200;
            // 
            // ColTotal
            // 
            this.ColTotal.HeaderText = "Total";
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.ReadOnly = true;
            // 
            // ColAcciones
            // 
            this.ColAcciones.HeaderText = "Accion";
            this.ColAcciones.Name = "ColAcciones";
            this.ColAcciones.ReadOnly = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(41, 405);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(141, 405);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 15;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(670, 415);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FrmConsultarPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvPresupuestos);
            this.Controls.Add(this.gbFiltros);
            this.Name = "FrmConsultarPresupuesto";
            this.Text = "ConsultarPresupuesto";
            this.Load += new System.EventHandler(this.ConsultarPresupuesto_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPresupuestos;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
        private System.Windows.Forms.DataGridViewButtonColumn ColAcciones;
    }
}