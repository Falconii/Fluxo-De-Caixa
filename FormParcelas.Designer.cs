
namespace Fluxo_De_Caixa
{
    partial class FormParcelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParcelas));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbVoltar = new System.Windows.Forms.ToolStripButton();
            this.gbIdentificacao = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtSaida = new System.Windows.Forms.MaskedTextBox();
            this.txtEntrada = new System.Windows.Forms.MaskedTextBox();
            this.lblSaida = new System.Windows.Forms.Label();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.tabVencimentos = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tbIncluir = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblAutomovel = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.gbIdentificacao.SuspendLayout();
            this.tabVencimentos.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbVoltar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(841, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "TooBar";
            // 
            // tbVoltar
            // 
            this.tbVoltar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbVoltar.Image = ((System.Drawing.Image)(resources.GetObject("tbVoltar.Image")));
            this.tbVoltar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbVoltar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbVoltar.Name = "tbVoltar";
            this.tbVoltar.Size = new System.Drawing.Size(36, 36);
            this.tbVoltar.ToolTipText = "Click Aqui Para Voltar";
            // 
            // gbIdentificacao
            // 
            this.gbIdentificacao.Controls.Add(this.lblAutomovel);
            this.gbIdentificacao.Controls.Add(this.textBox1);
            this.gbIdentificacao.Controls.Add(this.txtCliente);
            this.gbIdentificacao.Controls.Add(this.txtSaida);
            this.gbIdentificacao.Controls.Add(this.txtEntrada);
            this.gbIdentificacao.Controls.Add(this.lblSaida);
            this.gbIdentificacao.Controls.Add(this.lblEntrada);
            this.gbIdentificacao.Controls.Add(this.lblCliente);
            this.gbIdentificacao.Controls.Add(this.lblValor);
            this.gbIdentificacao.Controls.Add(this.txtValor);
            this.gbIdentificacao.Controls.Add(this.lblDocumento);
            this.gbIdentificacao.Controls.Add(this.txtDocumento);
            this.gbIdentificacao.Location = new System.Drawing.Point(0, 42);
            this.gbIdentificacao.Name = "gbIdentificacao";
            this.gbIdentificacao.Size = new System.Drawing.Size(813, 129);
            this.gbIdentificacao.TabIndex = 4;
            this.gbIdentificacao.TabStop = false;
            this.gbIdentificacao.Text = "Dados Da OS";
            // 
            // txtCliente
            // 
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Location = new System.Drawing.Point(13, 94);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(466, 20);
            this.txtCliente.TabIndex = 4;
            // 
            // txtSaida
            // 
            this.txtSaida.Location = new System.Drawing.Point(668, 94);
            this.txtSaida.Mask = "99/99/9999";
            this.txtSaida.Name = "txtSaida";
            this.txtSaida.PromptChar = ' ';
            this.txtSaida.Size = new System.Drawing.Size(116, 20);
            this.txtSaida.TabIndex = 6;
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(496, 93);
            this.txtEntrada.Mask = "99/99/9999";
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.PromptChar = ' ';
            this.txtEntrada.Size = new System.Drawing.Size(116, 20);
            this.txtEntrada.TabIndex = 5;
            // 
            // lblSaida
            // 
            this.lblSaida.AutoSize = true;
            this.lblSaida.Location = new System.Drawing.Point(665, 79);
            this.lblSaida.Name = "lblSaida";
            this.lblSaida.Size = new System.Drawing.Size(62, 13);
            this.lblSaida.TabIndex = 37;
            this.lblSaida.Text = "Data Saída";
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(495, 78);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(70, 13);
            this.lblEntrada.TabIndex = 36;
            this.lblEntrada.Text = "Data Entrada";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(10, 76);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 35;
            this.lblCliente.Text = "Cliente";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(173, 24);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 19;
            this.lblValor.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValor.Location = new System.Drawing.Point(176, 38);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(116, 20);
            this.txtValor.TabIndex = 1;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(10, 21);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 14;
            this.lblDocumento.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumento.Location = new System.Drawing.Point(13, 38);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(135, 20);
            this.txtDocumento.TabIndex = 0;
            // 
            // tabVencimentos
            // 
            this.tabVencimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabVencimentos.Controls.Add(this.tabPage1);
            this.tabVencimentos.Location = new System.Drawing.Point(13, 177);
            this.tabVencimentos.Name = "tabVencimentos";
            this.tabVencimentos.SelectedIndex = 0;
            this.tabVencimentos.Size = new System.Drawing.Size(800, 261);
            this.tabVencimentos.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Controls.Add(this.dbGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Baixas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbIncluir,
            this.tbDelete});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(786, 37);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "TooBar";
            // 
            // tbIncluir
            // 
            this.tbIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbIncluir.Image = ((System.Drawing.Image)(resources.GetObject("tbIncluir.Image")));
            this.tbIncluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbIncluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbIncluir.Name = "tbIncluir";
            this.tbIncluir.Size = new System.Drawing.Size(34, 34);
            this.tbIncluir.ToolTipText = "Clicl Aqui Para Incluir Uma Nova Baixa";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbDelete.Image")));
            this.tbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(34, 34);
            this.tbDelete.ToolTipText = "Click Aqui Para Excluir A Baixa";
            // 
            // dbGridView
            // 
            this.dbGridView.AllowUserToAddRows = false;
            this.dbGridView.AllowUserToOrderColumns = true;
            this.dbGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dbGridView.Location = new System.Drawing.Point(6, 44);
            this.dbGridView.MultiSelect = false;
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.Size = new System.Drawing.Size(786, 191);
            this.dbGridView.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(310, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(474, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lblAutomovel
            // 
            this.lblAutomovel.AutoSize = true;
            this.lblAutomovel.Location = new System.Drawing.Point(307, 24);
            this.lblAutomovel.Name = "lblAutomovel";
            this.lblAutomovel.Size = new System.Drawing.Size(57, 13);
            this.lblAutomovel.TabIndex = 42;
            this.lblAutomovel.Text = "Automovel";
            // 
            // FormParcelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 450);
            this.Controls.Add(this.tabVencimentos);
            this.Controls.Add(this.gbIdentificacao);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormParcelas";
            this.Text = "Pagemento OS";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbIdentificacao.ResumeLayout(false);
            this.gbIdentificacao.PerformLayout();
            this.tabVencimentos.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbVoltar;
        private System.Windows.Forms.GroupBox gbIdentificacao;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.MaskedTextBox txtSaida;
        private System.Windows.Forms.MaskedTextBox txtEntrada;
        private System.Windows.Forms.Label lblSaida;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TabControl tabVencimentos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tbIncluir;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private System.Windows.Forms.DataGridView dbGridView;
        private System.Windows.Forms.Label lblAutomovel;
        private System.Windows.Forms.TextBox textBox1;
    }
}