namespace Fluxo_De_Caixa
{
    partial class formBaixas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBaixas));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbIncluir = new System.Windows.Forms.ToolStripButton();
            this.tbEditar = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbOk = new System.Windows.Forms.ToolStripButton();
            this.tbCancelar = new System.Windows.Forms.ToolStripButton();
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbSenha = new System.Windows.Forms.GroupBox();
            this.lblVlrPago = new System.Windows.Forms.Label();
            this.txtVlrPago = new System.Windows.Forms.TextBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.lblJuros = new System.Windows.Forms.Label();
            this.txtJuros = new System.Windows.Forms.TextBox();
            this.lblAbatimento = new System.Windows.Forms.Label();
            this.txtAbatimento = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.gbIdentificacao = new System.Windows.Forms.GroupBox();
            this.txtCliFor = new System.Windows.Forms.TextBox();
            this.txtVencimento = new System.Windows.Forms.MaskedTextBox();
            this.txtEmissao = new System.Windows.Forms.MaskedTextBox();
            this.lblVencimento = new System.Windows.Forms.Label();
            this.lblEmissao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblParcela = new System.Windows.Forms.Label();
            this.txtParcela = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
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
            this.dbGridView.AllowUserToOrderColumns = true;
            this.dbGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dbGridView.Location = new System.Drawing.Point(0, 444);
            this.dbGridView.MultiSelect = false;
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.Size = new System.Drawing.Size(1022, 115);
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
            this.tabControl.Size = new System.Drawing.Size(1022, 396);
            this.tabControl.TabIndex = 4;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.groupBox1);
            this.tabPrincipal.Controls.Add(this.gbSenha);
            this.tabPrincipal.Controls.Add(this.gbIdentificacao);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipal.Size = new System.Drawing.Size(1014, 370);
            this.tabPrincipal.TabIndex = 1;
            this.tabPrincipal.Text = "Principal";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(965, 93);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "gbLancamento";
            // 
            // gbSenha
            // 
            this.gbSenha.Controls.Add(this.lblVlrPago);
            this.gbSenha.Controls.Add(this.txtVlrPago);
            this.gbSenha.Controls.Add(this.lblSaldo);
            this.gbSenha.Controls.Add(this.txtSaldo);
            this.gbSenha.Controls.Add(this.lblJuros);
            this.gbSenha.Controls.Add(this.txtJuros);
            this.gbSenha.Controls.Add(this.lblAbatimento);
            this.gbSenha.Controls.Add(this.txtAbatimento);
            this.gbSenha.Controls.Add(this.txtValor);
            this.gbSenha.Controls.Add(this.lblValor);
            this.gbSenha.Location = new System.Drawing.Point(12, 165);
            this.gbSenha.Name = "gbSenha";
            this.gbSenha.Size = new System.Drawing.Size(965, 100);
            this.gbSenha.TabIndex = 4;
            this.gbSenha.TabStop = false;
            this.gbSenha.Text = "Valores";
            this.gbSenha.Enter += new System.EventHandler(this.gbSenha_Enter);
            // 
            // lblVlrPago
            // 
            this.lblVlrPago.AutoSize = true;
            this.lblVlrPago.Location = new System.Drawing.Point(498, 34);
            this.lblVlrPago.Name = "lblVlrPago";
            this.lblVlrPago.Size = new System.Drawing.Size(47, 13);
            this.lblVlrPago.TabIndex = 43;
            this.lblVlrPago.Text = "Vlr Pago";
            // 
            // txtVlrPago
            // 
            this.txtVlrPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtVlrPago.Location = new System.Drawing.Point(501, 50);
            this.txtVlrPago.Name = "txtVlrPago";
            this.txtVlrPago.ReadOnly = true;
            this.txtVlrPago.Size = new System.Drawing.Size(130, 20);
            this.txtVlrPago.TabIndex = 14;
            this.txtVlrPago.TabStop = false;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(665, 34);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(34, 13);
            this.lblSaldo.TabIndex = 41;
            this.lblSaldo.Text = "Saldo";
            // 
            // txtSaldo
            // 
            this.txtSaldo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtSaldo.Location = new System.Drawing.Point(668, 50);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(130, 20);
            this.txtSaldo.TabIndex = 15;
            this.txtSaldo.TabStop = false;
            // 
            // lblJuros
            // 
            this.lblJuros.AutoSize = true;
            this.lblJuros.Location = new System.Drawing.Point(324, 34);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(32, 13);
            this.lblJuros.TabIndex = 39;
            this.lblJuros.Text = "Juros";
            // 
            // txtJuros
            // 
            this.txtJuros.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtJuros.Location = new System.Drawing.Point(327, 50);
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.Size = new System.Drawing.Size(130, 20);
            this.txtJuros.TabIndex = 13;
            this.txtJuros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsDoubleEntry);
            // 
            // lblAbatimento
            // 
            this.lblAbatimento.AutoSize = true;
            this.lblAbatimento.Location = new System.Drawing.Point(163, 34);
            this.lblAbatimento.Name = "lblAbatimento";
            this.lblAbatimento.Size = new System.Drawing.Size(60, 13);
            this.lblAbatimento.TabIndex = 37;
            this.lblAbatimento.Text = "Abatimento";
            // 
            // txtAbatimento
            // 
            this.txtAbatimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtAbatimento.Location = new System.Drawing.Point(166, 50);
            this.txtAbatimento.Name = "txtAbatimento";
            this.txtAbatimento.Size = new System.Drawing.Size(130, 20);
            this.txtAbatimento.TabIndex = 12;
            this.txtAbatimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsDoubleEntry);
            // 
            // txtValor
            // 
            this.txtValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtValor.Location = new System.Drawing.Point(13, 50);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(130, 20);
            this.txtValor.TabIndex = 11;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsDoubleEntry);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(10, 34);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 29;
            this.lblValor.Text = "Valor";
            // 
            // gbIdentificacao
            // 
            this.gbIdentificacao.Controls.Add(this.txtCliFor);
            this.gbIdentificacao.Controls.Add(this.txtVencimento);
            this.gbIdentificacao.Controls.Add(this.txtEmissao);
            this.gbIdentificacao.Controls.Add(this.lblVencimento);
            this.gbIdentificacao.Controls.Add(this.lblEmissao);
            this.gbIdentificacao.Controls.Add(this.lblCodigo);
            this.gbIdentificacao.Controls.Add(this.lblParcela);
            this.gbIdentificacao.Controls.Add(this.txtParcela);
            this.gbIdentificacao.Controls.Add(this.lblSerie);
            this.gbIdentificacao.Controls.Add(this.txtSerie);
            this.gbIdentificacao.Controls.Add(this.cbTipo);
            this.gbIdentificacao.Controls.Add(this.lblDocumento);
            this.gbIdentificacao.Controls.Add(this.txtDocumento);
            this.gbIdentificacao.Controls.Add(this.lblTipo);
            this.gbIdentificacao.Controls.Add(this.txtId);
            this.gbIdentificacao.Controls.Add(this.lblId);
            this.gbIdentificacao.Location = new System.Drawing.Point(12, 30);
            this.gbIdentificacao.Name = "gbIdentificacao";
            this.gbIdentificacao.Size = new System.Drawing.Size(965, 129);
            this.gbIdentificacao.TabIndex = 1;
            this.gbIdentificacao.TabStop = false;
            this.gbIdentificacao.Text = "Identificação";
            // 
            // txtCliFor
            // 
            this.txtCliFor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliFor.Location = new System.Drawing.Point(13, 94);
            this.txtCliFor.Name = "txtCliFor";
            this.txtCliFor.Size = new System.Drawing.Size(429, 20);
            this.txtCliFor.TabIndex = 40;
            // 
            // txtVencimento
            // 
            this.txtVencimento.Location = new System.Drawing.Point(668, 94);
            this.txtVencimento.Mask = "99/99/9999";
            this.txtVencimento.Name = "txtVencimento";
            this.txtVencimento.PromptChar = ' ';
            this.txtVencimento.Size = new System.Drawing.Size(116, 20);
            this.txtVencimento.TabIndex = 39;
            // 
            // txtEmissao
            // 
            this.txtEmissao.Location = new System.Drawing.Point(496, 93);
            this.txtEmissao.Mask = "99/99/9999";
            this.txtEmissao.Name = "txtEmissao";
            this.txtEmissao.PromptChar = ' ';
            this.txtEmissao.Size = new System.Drawing.Size(116, 20);
            this.txtEmissao.TabIndex = 38;
            // 
            // lblVencimento
            // 
            this.lblVencimento.AutoSize = true;
            this.lblVencimento.Location = new System.Drawing.Point(665, 79);
            this.lblVencimento.Name = "lblVencimento";
            this.lblVencimento.Size = new System.Drawing.Size(89, 13);
            this.lblVencimento.TabIndex = 37;
            this.lblVencimento.Text = "Data Vencimento";
            // 
            // lblEmissao
            // 
            this.lblEmissao.AutoSize = true;
            this.lblEmissao.Location = new System.Drawing.Point(495, 78);
            this.lblEmissao.Name = "lblEmissao";
            this.lblEmissao.Size = new System.Drawing.Size(72, 13);
            this.lblEmissao.TabIndex = 36;
            this.lblEmissao.Text = "Data Emissão";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(10, 76);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(98, 13);
            this.lblCodigo.TabIndex = 35;
            this.lblCodigo.Text = "Cliente/Fornecedor";
            // 
            // lblParcela
            // 
            this.lblParcela.AutoSize = true;
            this.lblParcela.Location = new System.Drawing.Point(665, 24);
            this.lblParcela.Name = "lblParcela";
            this.lblParcela.Size = new System.Drawing.Size(43, 13);
            this.lblParcela.TabIndex = 19;
            this.lblParcela.Text = "Parcela";
            // 
            // txtParcela
            // 
            this.txtParcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParcela.Location = new System.Drawing.Point(668, 38);
            this.txtParcela.Name = "txtParcela";
            this.txtParcela.Size = new System.Drawing.Size(116, 20);
            this.txtParcela.TabIndex = 5;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(493, 22);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(31, 13);
            this.lblSerie.TabIndex = 17;
            this.lblSerie.Text = "Série";
            // 
            // txtSerie
            // 
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Location = new System.Drawing.Point(496, 38);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(135, 20);
            this.txtSerie.TabIndex = 4;
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "RECEBER",
            "PAGAR"});
            this.cbTipo.Location = new System.Drawing.Point(146, 38);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(121, 21);
            this.cbTipo.TabIndex = 2;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(304, 22);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 14;
            this.lblDocumento.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumento.Location = new System.Drawing.Point(307, 39);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(135, 20);
            this.txtDocumento.TabIndex = 3;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(143, 23);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 12;
            this.lblTipo.Text = "Tipo";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(13, 39);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            this.txtId.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(10, 23);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "ID";
            // 
            // formBaixas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 561);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.dbGridView);
            this.Name = "formBaixas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro De Documentos";
            this.TopMost = true;
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
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label lblJuros;
        private System.Windows.Forms.TextBox txtJuros;
        private System.Windows.Forms.Label lblAbatimento;
        private System.Windows.Forms.TextBox txtAbatimento;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lblParcela;
        private System.Windows.Forms.TextBox txtParcela;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblVlrPago;
        private System.Windows.Forms.TextBox txtVlrPago;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtVencimento;
        private System.Windows.Forms.MaskedTextBox txtEmissao;
        private System.Windows.Forms.Label lblVencimento;
        private System.Windows.Forms.Label lblEmissao;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCliFor;
    }
}