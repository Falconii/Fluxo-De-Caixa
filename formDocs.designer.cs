namespace Fluxo_De_Caixa
{
    partial class formDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDocs));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbBrowser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbPesquisar = new System.Windows.Forms.ToolStripLabel();
            this.cbPesquisar = new System.Windows.Forms.ToolStripComboBox();
            this.edPesquisar = new System.Windows.Forms.ToolStripTextBox();
            this.btBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tpCbCliFor = new System.Windows.Forms.ToolStripComboBox();
            this.tbIncluir = new System.Windows.Forms.ToolStripButton();
            this.tbEditar = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbOk = new System.Windows.Forms.ToolStripButton();
            this.tbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tbBaixar = new System.Windows.Forms.ToolStripButton();
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.gbComplemento = new System.Windows.Forms.GroupBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.lblObs = new System.Windows.Forms.Label();
            this.gbDatas = new System.Windows.Forms.GroupBox();
            this.txtVencimento = new System.Windows.Forms.MaskedTextBox();
            this.txtEmissao = new System.Windows.Forms.MaskedTextBox();
            this.lblVencimento = new System.Windows.Forms.Label();
            this.lblEmissao = new System.Windows.Forms.Label();
            this.gbClifor = new System.Windows.Forms.GroupBox();
            this.cbCliFor = new System.Windows.Forms.ComboBox();
            this.lblConta = new System.Windows.Forms.Label();
            this.txtConta = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
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
            this.gbComplemento.SuspendLayout();
            this.gbDatas.SuspendLayout();
            this.gbClifor.SuspendLayout();
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
            this.tpCbCliFor,
            this.tbIncluir,
            this.tbEditar,
            this.tbDelete,
            this.tbOk,
            this.tbCancelar,
            this.tbBaixar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1340, 39);
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
            "DOCUMENTO",
            "EMISSÃO",
            "VENCIMENTO"});
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
            // tpCbCliFor
            // 
            this.tpCbCliFor.Name = "tpCbCliFor";
            this.tpCbCliFor.Size = new System.Drawing.Size(300, 39);
            this.tpCbCliFor.Click += new System.EventHandler(this.toolStripComboBox1_Click);
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
            // tbBaixar
            // 
            this.tbBaixar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBaixar.Image = ((System.Drawing.Image)(resources.GetObject("tbBaixar.Image")));
            this.tbBaixar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbBaixar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBaixar.Name = "tbBaixar";
            this.tbBaixar.Size = new System.Drawing.Size(34, 36);
            this.tbBaixar.ToolTipText = "Click Aqui Para Confirmar";
            this.tbBaixar.Click += new System.EventHandler(this.tbBaixar_Click);
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
            this.dbGridView.Size = new System.Drawing.Size(1340, 685);
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
            this.tabControl.Size = new System.Drawing.Size(1340, 689);
            this.tabControl.TabIndex = 4;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.gbComplemento);
            this.tabPrincipal.Controls.Add(this.gbDatas);
            this.tabPrincipal.Controls.Add(this.gbClifor);
            this.tabPrincipal.Controls.Add(this.gbSenha);
            this.tabPrincipal.Controls.Add(this.gbIdentificacao);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipal.Size = new System.Drawing.Size(1332, 663);
            this.tabPrincipal.TabIndex = 1;
            this.tabPrincipal.Text = "Principal";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // gbComplemento
            // 
            this.gbComplemento.Controls.Add(this.txtObs);
            this.gbComplemento.Controls.Add(this.lblObs);
            this.gbComplemento.Location = new System.Drawing.Point(37, 536);
            this.gbComplemento.Name = "gbComplemento";
            this.gbComplemento.Size = new System.Drawing.Size(965, 100);
            this.gbComplemento.TabIndex = 44;
            this.gbComplemento.TabStop = false;
            this.gbComplemento.Text = "Complemento";
            // 
            // txtObs
            // 
            this.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtObs.Location = new System.Drawing.Point(13, 50);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(613, 20);
            this.txtObs.TabIndex = 16;
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(10, 34);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(65, 13);
            this.lblObs.TabIndex = 29;
            this.lblObs.Text = "Observação";
            // 
            // gbDatas
            // 
            this.gbDatas.Controls.Add(this.txtVencimento);
            this.gbDatas.Controls.Add(this.txtEmissao);
            this.gbDatas.Controls.Add(this.lblVencimento);
            this.gbDatas.Controls.Add(this.lblEmissao);
            this.gbDatas.Location = new System.Drawing.Point(37, 287);
            this.gbDatas.Name = "gbDatas";
            this.gbDatas.Size = new System.Drawing.Size(965, 100);
            this.gbDatas.TabIndex = 3;
            this.gbDatas.TabStop = false;
            this.gbDatas.Text = "Datas";
            // 
            // txtVencimento
            // 
            this.txtVencimento.Location = new System.Drawing.Point(220, 46);
            this.txtVencimento.Mask = "99/99/9999";
            this.txtVencimento.Name = "txtVencimento";
            this.txtVencimento.PromptChar = ' ';
            this.txtVencimento.Size = new System.Drawing.Size(116, 20);
            this.txtVencimento.TabIndex = 10;
            // 
            // txtEmissao
            // 
            this.txtEmissao.Location = new System.Drawing.Point(13, 46);
            this.txtEmissao.Mask = "99/99/9999";
            this.txtEmissao.Name = "txtEmissao";
            this.txtEmissao.PromptChar = ' ';
            this.txtEmissao.Size = new System.Drawing.Size(116, 20);
            this.txtEmissao.TabIndex = 9;
            // 
            // lblVencimento
            // 
            this.lblVencimento.AutoSize = true;
            this.lblVencimento.Location = new System.Drawing.Point(217, 31);
            this.lblVencimento.Name = "lblVencimento";
            this.lblVencimento.Size = new System.Drawing.Size(89, 13);
            this.lblVencimento.TabIndex = 7;
            this.lblVencimento.Text = "Data Vencimento";
            // 
            // lblEmissao
            // 
            this.lblEmissao.AutoSize = true;
            this.lblEmissao.Location = new System.Drawing.Point(12, 31);
            this.lblEmissao.Name = "lblEmissao";
            this.lblEmissao.Size = new System.Drawing.Size(72, 13);
            this.lblEmissao.TabIndex = 6;
            this.lblEmissao.Text = "Data Emissão";
            // 
            // gbClifor
            // 
            this.gbClifor.Controls.Add(this.cbCliFor);
            this.gbClifor.Controls.Add(this.lblConta);
            this.gbClifor.Controls.Add(this.txtConta);
            this.gbClifor.Controls.Add(this.lblCodigo);
            this.gbClifor.Location = new System.Drawing.Point(37, 155);
            this.gbClifor.Name = "gbClifor";
            this.gbClifor.Size = new System.Drawing.Size(965, 100);
            this.gbClifor.TabIndex = 2;
            this.gbClifor.TabStop = false;
            this.gbClifor.Text = "Cliente/Fornecedor";
            // 
            // cbCliFor
            // 
            this.cbCliFor.FormattingEnabled = true;
            this.cbCliFor.Location = new System.Drawing.Point(13, 51);
            this.cbCliFor.Name = "cbCliFor";
            this.cbCliFor.Size = new System.Drawing.Size(572, 21);
            this.cbCliFor.TabIndex = 1;
            this.cbCliFor.SelectedIndexChanged += new System.EventHandler(this.cbCliFor_SelectedIndexChanged);
            // 
            // lblConta
            // 
            this.lblConta.AutoSize = true;
            this.lblConta.Location = new System.Drawing.Point(632, 34);
            this.lblConta.Name = "lblConta";
            this.lblConta.Size = new System.Drawing.Size(35, 13);
            this.lblConta.TabIndex = 39;
            this.lblConta.Text = "Conta";
            // 
            // txtConta
            // 
            this.txtConta.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtConta.Location = new System.Drawing.Point(635, 50);
            this.txtConta.Name = "txtConta";
            this.txtConta.ReadOnly = true;
            this.txtConta.Size = new System.Drawing.Size(324, 20);
            this.txtConta.TabIndex = 8;
            this.txtConta.TabStop = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(10, 34);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 29;
            this.lblCodigo.Text = "Código";
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
            this.gbSenha.Location = new System.Drawing.Point(37, 409);
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
            this.txtJuros.Leave += new System.EventHandler(this.txtValor_Leave);
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
            this.txtAbatimento.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // txtValor
            // 
            this.txtValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtValor.Location = new System.Drawing.Point(13, 50);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(130, 20);
            this.txtValor.TabIndex = 11;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsDoubleEntry);
            this.txtValor.Leave += new System.EventHandler(this.txtValor_Leave);
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
            this.gbIdentificacao.Location = new System.Drawing.Point(37, 30);
            this.gbIdentificacao.Name = "gbIdentificacao";
            this.gbIdentificacao.Size = new System.Drawing.Size(965, 100);
            this.gbIdentificacao.TabIndex = 1;
            this.gbIdentificacao.TabStop = false;
            this.gbIdentificacao.Text = "Identificação";
            // 
            // lblParcela
            // 
            this.lblParcela.AutoSize = true;
            this.lblParcela.Location = new System.Drawing.Point(688, 33);
            this.lblParcela.Name = "lblParcela";
            this.lblParcela.Size = new System.Drawing.Size(43, 13);
            this.lblParcela.TabIndex = 19;
            this.lblParcela.Text = "Parcela";
            // 
            // txtParcela
            // 
            this.txtParcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParcela.Location = new System.Drawing.Point(691, 47);
            this.txtParcela.Name = "txtParcela";
            this.txtParcela.Size = new System.Drawing.Size(74, 20);
            this.txtParcela.TabIndex = 5;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(493, 31);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(31, 13);
            this.lblSerie.TabIndex = 17;
            this.lblSerie.Text = "Série";
            // 
            // txtSerie
            // 
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Location = new System.Drawing.Point(496, 47);
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
            this.cbTipo.Location = new System.Drawing.Point(146, 47);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(121, 21);
            this.cbTipo.TabIndex = 2;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(304, 31);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 14;
            this.lblDocumento.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumento.Location = new System.Drawing.Point(307, 48);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(135, 20);
            this.txtDocumento.TabIndex = 3;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(143, 32);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 12;
            this.lblTipo.Text = "Tipo";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(13, 48);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            this.txtId.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(10, 32);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "ID";
            // 
            // formDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 731);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.dbGridView);
            this.Name = "formDocs";
            this.Text = "Cadastro De Documentos";
            this.Activated += new System.EventHandler(this.FormUsuarios_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.gbComplemento.ResumeLayout(false);
            this.gbComplemento.PerformLayout();
            this.gbDatas.ResumeLayout(false);
            this.gbDatas.PerformLayout();
            this.gbClifor.ResumeLayout(false);
            this.gbClifor.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbComplemento;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.GroupBox gbDatas;
        private System.Windows.Forms.MaskedTextBox txtVencimento;
        private System.Windows.Forms.MaskedTextBox txtEmissao;
        private System.Windows.Forms.Label lblVencimento;
        private System.Windows.Forms.Label lblEmissao;
        private System.Windows.Forms.GroupBox gbClifor;
        private System.Windows.Forms.Label lblConta;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblVlrPago;
        private System.Windows.Forms.TextBox txtVlrPago;
        private System.Windows.Forms.ComboBox cbCliFor;
        private System.Windows.Forms.ToolStripButton tbBaixar;
        private System.Windows.Forms.ToolStripComboBox tpCbCliFor;
    }
}