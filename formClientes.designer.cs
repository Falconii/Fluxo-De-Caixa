namespace Fluxo_De_Caixa
{
    partial class formClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formClientes));
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.gbSenha = new System.Windows.Forms.GroupBox();
            this.cbConta = new System.Windows.Forms.ComboBox();
            this.lbConta = new System.Windows.Forms.Label();
            this.txtTel1 = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTel1 = new System.Windows.Forms.Label();
            this.gbIdentificacao = new System.Windows.Forms.GroupBox();
            this.lblFantasi = new System.Windows.Forms.Label();
            this.txtFantasi = new System.Windows.Forms.TextBox();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.lblRazao = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.gbSenha.SuspendLayout();
            this.gbIdentificacao.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1022, 39);
            this.toolStrip1.TabIndex = 2;
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
            this.tbBrowser.Click += new System.EventHandler(this.TbBrowser_Click);
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
            this.cbPesquisar.SelectedIndexChanged += new System.EventHandler(this.CbPesquisar_SelectedIndexChanged);
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
            this.btBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
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
            this.tbIncluir.Click += new System.EventHandler(this.TbIncluir_Click);
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
            this.tbEditar.Click += new System.EventHandler(this.TbEditar_Click);
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
            this.tbDelete.Click += new System.EventHandler(this.TbDelete_Click);
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
            this.tbOk.Click += new System.EventHandler(this.TbOk_Click);
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
            this.tbCancelar.Click += new System.EventHandler(this.TbCancelar_Click);
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
            this.dbGridView.Size = new System.Drawing.Size(1022, 388);
            this.dbGridView.TabIndex = 3;
            this.dbGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DbGridView_RowEnter);
            this.dbGridView.DoubleClick += new System.EventHandler(this.DbGridView_DoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPrincipal);
            this.tabControl.Location = new System.Drawing.Point(0, 42);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1022, 392);
            this.tabControl.TabIndex = 4;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.gbSenha);
            this.tabPrincipal.Controls.Add(this.gbIdentificacao);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipal.Size = new System.Drawing.Size(1014, 366);
            this.tabPrincipal.TabIndex = 1;
            this.tabPrincipal.Text = "Principal";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // gbSenha
            // 
            this.gbSenha.Controls.Add(this.cbConta);
            this.gbSenha.Controls.Add(this.lbConta);
            this.gbSenha.Controls.Add(this.txtTel1);
            this.gbSenha.Controls.Add(this.txtEmail);
            this.gbSenha.Controls.Add(this.lblEmail);
            this.gbSenha.Controls.Add(this.lblTel1);
            this.gbSenha.Location = new System.Drawing.Point(37, 154);
            this.gbSenha.Name = "gbSenha";
            this.gbSenha.Size = new System.Drawing.Size(965, 100);
            this.gbSenha.TabIndex = 23;
            this.gbSenha.TabStop = false;
            this.gbSenha.Text = "E-Mail";
            // 
            // cbConta
            // 
            this.cbConta.FormattingEnabled = true;
            this.cbConta.Location = new System.Drawing.Point(595, 50);
            this.cbConta.Name = "cbConta";
            this.cbConta.Size = new System.Drawing.Size(364, 21);
            this.cbConta.TabIndex = 6;
            // 
            // lbConta
            // 
            this.lbConta.AutoSize = true;
            this.lbConta.Location = new System.Drawing.Point(595, 34);
            this.lbConta.Name = "lbConta";
            this.lbConta.Size = new System.Drawing.Size(35, 13);
            this.lbConta.TabIndex = 34;
            this.lbConta.Text = "Conta";
            // 
            // txtTel1
            // 
            this.txtTel1.Location = new System.Drawing.Point(13, 50);
            this.txtTel1.Mask = "(999) #9999-9999";
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.PromptChar = ' ';
            this.txtTel1.Size = new System.Drawing.Size(160, 20);
            this.txtTel1.TabIndex = 4;
            this.txtTel1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(211, 50);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(352, 20);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(208, 34);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 13);
            this.lblEmail.TabIndex = 27;
            this.lblEmail.Text = "E-Mail";
            // 
            // lblTel1
            // 
            this.lblTel1.AutoSize = true;
            this.lblTel1.Location = new System.Drawing.Point(10, 34);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(58, 13);
            this.lblTel1.TabIndex = 29;
            this.lblTel1.Text = "Telefone 1";
            // 
            // gbIdentificacao
            // 
            this.gbIdentificacao.Controls.Add(this.lblFantasi);
            this.gbIdentificacao.Controls.Add(this.txtFantasi);
            this.gbIdentificacao.Controls.Add(this.txtRazao);
            this.gbIdentificacao.Controls.Add(this.lblRazao);
            this.gbIdentificacao.Controls.Add(this.txtCodigo);
            this.gbIdentificacao.Controls.Add(this.lblCodigo);
            this.gbIdentificacao.Location = new System.Drawing.Point(37, 30);
            this.gbIdentificacao.Name = "gbIdentificacao";
            this.gbIdentificacao.Size = new System.Drawing.Size(965, 100);
            this.gbIdentificacao.TabIndex = 1;
            this.gbIdentificacao.TabStop = false;
            this.gbIdentificacao.Text = "Identificação";
            // 
            // lblFantasi
            // 
            this.lblFantasi.AutoSize = true;
            this.lblFantasi.Location = new System.Drawing.Point(592, 31);
            this.lblFantasi.Name = "lblFantasi";
            this.lblFantasi.Size = new System.Drawing.Size(41, 13);
            this.lblFantasi.TabIndex = 14;
            this.lblFantasi.Text = "Fantasi";
            // 
            // txtFantasi
            // 
            this.txtFantasi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFantasi.Location = new System.Drawing.Point(595, 48);
            this.txtFantasi.Name = "txtFantasi";
            this.txtFantasi.Size = new System.Drawing.Size(364, 20);
            this.txtFantasi.TabIndex = 3;
            // 
            // txtRazao
            // 
            this.txtRazao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazao.Location = new System.Drawing.Point(134, 47);
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(429, 20);
            this.txtRazao.TabIndex = 2;
            // 
            // lblRazao
            // 
            this.lblRazao.AutoSize = true;
            this.lblRazao.Location = new System.Drawing.Point(131, 31);
            this.lblRazao.Name = "lblRazao";
            this.lblRazao.Size = new System.Drawing.Size(70, 13);
            this.lblRazao.TabIndex = 12;
            this.lblRazao.Text = "Razão Social";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(13, 48);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TabStop = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(10, 32);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 8;
            this.lblCodigo.Text = "Codigo";
            // 
            // formClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 434);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dbGridView);
            this.Controls.Add(this.tabControl);
            this.Name = "formClientes";
            this.Text = "Cadastro De Clientes";
            this.Activated += new System.EventHandler(this.FormUsuarios_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.gbSenha.ResumeLayout(false);
            this.gbSenha.PerformLayout();
            this.gbIdentificacao.ResumeLayout(false);
            this.gbIdentificacao.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.GroupBox gbSenha;
        private System.Windows.Forms.GroupBox gbIdentificacao;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.Label lblRazao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lbConta;
        private System.Windows.Forms.MaskedTextBox txtTel1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTel1;
        private System.Windows.Forms.Label lblFantasi;
        private System.Windows.Forms.TextBox txtFantasi;
        private System.Windows.Forms.ComboBox cbConta;
    }
}