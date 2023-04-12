
namespace Fluxo_De_Caixa
{
    partial class FormFluxo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFluxo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbBrowser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbPesquisar = new System.Windows.Forms.ToolStripLabel();
            this.cbPesquisar = new System.Windows.Forms.ToolStripComboBox();
            this.edPesquisar = new System.Windows.Forms.ToolStripTextBox();
            this.btBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbIncluir = new System.Windows.Forms.ToolStripButton();
            this.tbEditar = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbOk = new System.Windows.Forms.ToolStripButton();
            this.tbCancelar = new System.Windows.Forms.ToolStripButton();
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbBrowser,
            this.toolStripSeparator1,
            this.lbPesquisar,
            this.cbPesquisar,
            this.edPesquisar,
            this.btBuscar,
            this.toolStripSeparator2,
            this.tbIncluir,
            this.tbEditar,
            this.tbDelete,
            this.tbOk,
            this.tbCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "TooBar";
            // 
            // tbBrowser
            // 
            this.tbBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBrowser.Image = ((System.Drawing.Image)(resources.GetObject("tbBrowser.Image")));
            this.tbBrowser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBrowser.Name = "tbBrowser";
            this.tbBrowser.Size = new System.Drawing.Size(34, 36);
            this.tbBrowser.ToolTipText = "Click Para Alternar As Visões de Browser e Consulta";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 39);
            // 
            // lbPesquisar
            // 
            this.lbPesquisar.Name = "lbPesquisar";
            this.lbPesquisar.Size = new System.Drawing.Size(53, 36);
            this.lbPesquisar.Text = "Pesquisa";
            // 
            // cbPesquisar
            // 
            this.cbPesquisar.Items.AddRange(new object[] {
            "CÓDIGO",
            "RAZÃO SOCIAL",
            "FANTASIA"});
            this.cbPesquisar.Name = "cbPesquisar";
            this.cbPesquisar.Size = new System.Drawing.Size(121, 39);
            // 
            // edPesquisar
            // 
            this.edPesquisar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.edPesquisar.Name = "edPesquisar";
            this.edPesquisar.Size = new System.Drawing.Size(250, 39);
            // 
            // btBuscar
            // 
            this.btBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btBuscar.Image")));
            this.btBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(23, 36);
            this.btBuscar.Text = "Click Aqui Para Pesquisar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(50, 39);
            // 
            // tbIncluir
            // 
            this.tbIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbIncluir.Image = ((System.Drawing.Image)(resources.GetObject("tbIncluir.Image")));
            this.tbIncluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbIncluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbIncluir.Name = "tbIncluir";
            this.tbIncluir.Size = new System.Drawing.Size(34, 36);
            this.tbIncluir.ToolTipText = "Clicl Aqui Para Incluir Um Usuario  Novo";
            // 
            // tbEditar
            // 
            this.tbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tbEditar.Image")));
            this.tbEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbEditar.Name = "tbEditar";
            this.tbEditar.Size = new System.Drawing.Size(34, 36);
            this.tbEditar.ToolTipText = "Click Aqui Para Editar O Usuário";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbDelete.Image")));
            this.tbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(34, 36);
            this.tbDelete.ToolTipText = "Click Aqui Para Excluir O Usuário";
            // 
            // tbOk
            // 
            this.tbOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOk.Image = ((System.Drawing.Image)(resources.GetObject("tbOk.Image")));
            this.tbOk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOk.Name = "tbOk";
            this.tbOk.Size = new System.Drawing.Size(34, 36);
            this.tbOk.ToolTipText = "Click Aqui Para Confirmar";
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
            this.dbGridView.Location = new System.Drawing.Point(0, 42);
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.ReadOnly = true;
            this.dbGridView.Size = new System.Drawing.Size(800, 407);
            this.dbGridView.TabIndex = 4;
            // 
            // FormFluxo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dbGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormFluxo";
            this.Text = "Fluxo De Caixa";
            this.Activated += new System.EventHandler(this.FormFluxo_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFluxo_FormClosed);
            this.Load += new System.EventHandler(this.FormFluxo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbBrowser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbPesquisar;
        private System.Windows.Forms.ToolStripComboBox cbPesquisar;
        private System.Windows.Forms.ToolStripTextBox edPesquisar;
        private System.Windows.Forms.ToolStripButton btBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbIncluir;
        private System.Windows.Forms.ToolStripButton tbEditar;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private System.Windows.Forms.ToolStripButton tbOk;
        private System.Windows.Forms.ToolStripButton tbCancelar;
        private System.Windows.Forms.DataGridView dbGridView;
    }
}