
namespace Fluxo_De_Caixa
{
    partial class FormRecPag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecPag));
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbCancelar = new System.Windows.Forms.ToolStripButton();
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.lblCliFor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInicial = new System.Windows.Forms.Label();
            this.lblTupo = new System.Windows.Forms.Label();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.cbCliFor = new System.Windows.Forms.ComboBox();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.dtInicial = new System.Windows.Forms.DateTimePicker();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.tbExcel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.gbParametros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbGridView
            // 
            this.dbGridView.AllowUserToAddRows = false;
            this.dbGridView.AllowUserToDeleteRows = false;
            this.dbGridView.AllowUserToOrderColumns = true;
            this.dbGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridView.Location = new System.Drawing.Point(0, 113);
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.ReadOnly = true;
            this.dbGridView.Size = new System.Drawing.Size(1033, 337);
            this.dbGridView.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btBuscar,
            this.tbExcel,
            this.toolStripSeparator2,
            this.tbCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1033, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "TooBar";
            // 
            // btBuscar
            // 
            this.btBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btBuscar.Image")));
            this.btBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(23, 36);
            this.btBuscar.Text = "Click Aqui Para Pesquisar";
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(25, 39);
            // 
            // tbCancelar
            // 
            this.tbCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tbCancelar.Image")));
            this.tbCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCancelar.Name = "tbCancelar";
            this.tbCancelar.Size = new System.Drawing.Size(36, 36);
            this.tbCancelar.ToolTipText = "Click Aqui Para Cancelar";
            this.tbCancelar.Click += new System.EventHandler(this.tbCancelar_Click);
            // 
            // gbParametros
            // 
            this.gbParametros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbParametros.Controls.Add(this.lblSituacao);
            this.gbParametros.Controls.Add(this.lblCliFor);
            this.gbParametros.Controls.Add(this.label1);
            this.gbParametros.Controls.Add(this.lblInicial);
            this.gbParametros.Controls.Add(this.lblTupo);
            this.gbParametros.Controls.Add(this.cbSituacao);
            this.gbParametros.Controls.Add(this.cbCliFor);
            this.gbParametros.Controls.Add(this.dtFinal);
            this.gbParametros.Controls.Add(this.dtInicial);
            this.gbParametros.Controls.Add(this.cbTipo);
            this.gbParametros.Location = new System.Drawing.Point(0, 46);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Size = new System.Drawing.Size(1033, 61);
            this.gbParametros.TabIndex = 7;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Parâmetros";
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Location = new System.Drawing.Point(772, 16);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(49, 13);
            this.lblSituacao.TabIndex = 9;
            this.lblSituacao.Text = "Situação";
            // 
            // lblCliFor
            // 
            this.lblCliFor.AutoSize = true;
            this.lblCliFor.Location = new System.Drawing.Point(465, 19);
            this.lblCliFor.Name = "lblCliFor";
            this.lblCliFor.Size = new System.Drawing.Size(98, 13);
            this.lblCliFor.TabIndex = 8;
            this.lblCliFor.Text = "Cliente/Fornecedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo";
            // 
            // lblInicial
            // 
            this.lblInicial.AutoSize = true;
            this.lblInicial.Location = new System.Drawing.Point(185, 19);
            this.lblInicial.Name = "lblInicial";
            this.lblInicial.Size = new System.Drawing.Size(28, 13);
            this.lblInicial.TabIndex = 6;
            this.lblInicial.Text = "Tipo";
            // 
            // lblTupo
            // 
            this.lblTupo.AutoSize = true;
            this.lblTupo.Location = new System.Drawing.Point(12, 18);
            this.lblTupo.Name = "lblTupo";
            this.lblTupo.Size = new System.Drawing.Size(28, 13);
            this.lblTupo.TabIndex = 5;
            this.lblTupo.Text = "Tipo";
            // 
            // cbSituacao
            // 
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Items.AddRange(new object[] {
            "Todos",
            "Em Aberto",
            "Em Atraso",
            "Encerrados"});
            this.cbSituacao.Location = new System.Drawing.Point(775, 34);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(126, 21);
            this.cbSituacao.TabIndex = 4;
            this.cbSituacao.SelectedIndexChanged += new System.EventHandler(this.cbSituacao_SelectedIndexChanged);
            // 
            // cbCliFor
            // 
            this.cbCliFor.FormattingEnabled = true;
            this.cbCliFor.Location = new System.Drawing.Point(468, 35);
            this.cbCliFor.Name = "cbCliFor";
            this.cbCliFor.Size = new System.Drawing.Size(277, 21);
            this.cbCliFor.TabIndex = 3;
            // 
            // dtFinal
            // 
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFinal.Location = new System.Drawing.Point(330, 35);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(110, 20);
            this.dtFinal.TabIndex = 2;
            // 
            // dtInicial
            // 
            this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicial.Location = new System.Drawing.Point(188, 35);
            this.dtInicial.Name = "dtInicial";
            this.dtInicial.Size = new System.Drawing.Size(108, 20);
            this.dtInicial.TabIndex = 1;
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Receber",
            "Pagar"});
            this.cbTipo.Location = new System.Drawing.Point(12, 34);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(152, 21);
            this.cbTipo.TabIndex = 0;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // tbExcel
            // 
            this.tbExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbExcel.Image = ((System.Drawing.Image)(resources.GetObject("tbExcel.Image")));
            this.tbExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExcel.Name = "tbExcel";
            this.tbExcel.Size = new System.Drawing.Size(34, 36);
            this.tbExcel.Click += new System.EventHandler(this.tbExcel_Click);
            // 
            // FormRecPag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 450);
            this.Controls.Add(this.gbParametros);
            this.Controls.Add(this.dbGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormRecPag";
            this.Text = "Pagar & Receber";
            this.Activated += new System.EventHandler(this.FormRecPag_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRecPag_FormClosed);
            this.Load += new System.EventHandler(this.FormRecPag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbParametros.ResumeLayout(false);
            this.gbParametros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbCancelar;
        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.ComboBox cbCliFor;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.DateTimePicker dtInicial;
        private System.Windows.Forms.Label lblTupo;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Label lblCliFor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInicial;
        private System.Windows.Forms.ToolStripButton tbExcel;
    }
}