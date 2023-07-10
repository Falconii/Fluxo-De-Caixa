
namespace Fluxo_De_Caixa
{
    partial class FormEncerramento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEncerramento));
            this.gbIdentificacao = new System.Windows.Forms.GroupBox();
            this.txtEntrada = new System.Windows.Forms.MaskedTextBox();
            this.lblTotalCabec = new System.Windows.Forms.Label();
            this.txtValorOS = new System.Windows.Forms.TextBox();
            this.lblValorDeMaoDeObraCabec = new System.Windows.Forms.Label();
            this.txtVlrMaoDeMaoDeObra = new System.Windows.Forms.TextBox();
            this.lblVlrPecasCabec = new System.Windows.Forms.Label();
            this.txtVlrDasPecas = new System.Windows.Forms.TextBox();
            this.txtSaida = new System.Windows.Forms.MaskedTextBox();
            this.lblSaida = new System.Windows.Forms.Label();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbCancelar = new System.Windows.Forms.ToolStripButton();
            this.gbValores = new System.Windows.Forms.GroupBox();
            this.btEncerrar = new System.Windows.Forms.Button();
            this.lblValorTitulo = new System.Windows.Forms.Label();
            this.txtValorTitulo = new System.Windows.Forms.TextBox();
            this.lblAbatimento = new System.Windows.Forms.Label();
            this.txtVlrAbatimento = new System.Windows.Forms.TextBox();
            this.lblAcrescimo = new System.Windows.Forms.Label();
            this.txtVlrAcrescimo = new System.Windows.Forms.TextBox();
            this.txtVencimento = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbIdentificacao.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbValores.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbIdentificacao
            // 
            this.gbIdentificacao.Controls.Add(this.txtEntrada);
            this.gbIdentificacao.Controls.Add(this.lblTotalCabec);
            this.gbIdentificacao.Controls.Add(this.txtValorOS);
            this.gbIdentificacao.Controls.Add(this.lblValorDeMaoDeObraCabec);
            this.gbIdentificacao.Controls.Add(this.txtVlrMaoDeMaoDeObra);
            this.gbIdentificacao.Controls.Add(this.lblVlrPecasCabec);
            this.gbIdentificacao.Controls.Add(this.txtVlrDasPecas);
            this.gbIdentificacao.Controls.Add(this.txtSaida);
            this.gbIdentificacao.Controls.Add(this.lblSaida);
            this.gbIdentificacao.Controls.Add(this.lblEntrada);
            this.gbIdentificacao.Controls.Add(this.txtId);
            this.gbIdentificacao.Controls.Add(this.lblId);
            this.gbIdentificacao.Location = new System.Drawing.Point(12, 42);
            this.gbIdentificacao.Name = "gbIdentificacao";
            this.gbIdentificacao.Size = new System.Drawing.Size(888, 100);
            this.gbIdentificacao.TabIndex = 2;
            this.gbIdentificacao.TabStop = false;
            this.gbIdentificacao.Text = "Identificação";
            // 
            // txtEntrada
            // 
            this.txtEntrada.Enabled = false;
            this.txtEntrada.Location = new System.Drawing.Point(154, 48);
            this.txtEntrada.Mask = "99/99/99";
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.PromptChar = ' ';
            this.txtEntrada.Size = new System.Drawing.Size(116, 20);
            this.txtEntrada.TabIndex = 1;
            // 
            // lblTotalCabec
            // 
            this.lblTotalCabec.AutoSize = true;
            this.lblTotalCabec.Location = new System.Drawing.Point(749, 32);
            this.lblTotalCabec.Name = "lblTotalCabec";
            this.lblTotalCabec.Size = new System.Drawing.Size(99, 13);
            this.lblTotalCabec.TabIndex = 49;
            this.lblTotalCabec.Text = "Valor Total Da O.S.";
            // 
            // txtValorOS
            // 
            this.txtValorOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtValorOS.Location = new System.Drawing.Point(752, 48);
            this.txtValorOS.Name = "txtValorOS";
            this.txtValorOS.Size = new System.Drawing.Size(130, 20);
            this.txtValorOS.TabIndex = 5;
            this.txtValorOS.TabStop = false;
            this.txtValorOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorDeMaoDeObraCabec
            // 
            this.lblValorDeMaoDeObraCabec.AutoSize = true;
            this.lblValorDeMaoDeObraCabec.Location = new System.Drawing.Point(437, 31);
            this.lblValorDeMaoDeObraCabec.Name = "lblValorDeMaoDeObraCabec";
            this.lblValorDeMaoDeObraCabec.Size = new System.Drawing.Size(106, 13);
            this.lblValorDeMaoDeObraCabec.TabIndex = 47;
            this.lblValorDeMaoDeObraCabec.Text = "Vlr  Da Mão De Obra";
            // 
            // txtVlrMaoDeMaoDeObra
            // 
            this.txtVlrMaoDeMaoDeObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtVlrMaoDeMaoDeObra.Location = new System.Drawing.Point(440, 48);
            this.txtVlrMaoDeMaoDeObra.Name = "txtVlrMaoDeMaoDeObra";
            this.txtVlrMaoDeMaoDeObra.Size = new System.Drawing.Size(130, 20);
            this.txtVlrMaoDeMaoDeObra.TabIndex = 3;
            this.txtVlrMaoDeMaoDeObra.TabStop = false;
            this.txtVlrMaoDeMaoDeObra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVlrPecasCabec
            // 
            this.lblVlrPecasCabec.AutoSize = true;
            this.lblVlrPecasCabec.Location = new System.Drawing.Point(594, 32);
            this.lblVlrPecasCabec.Name = "lblVlrPecasCabec";
            this.lblVlrPecasCabec.Size = new System.Drawing.Size(74, 13);
            this.lblVlrPecasCabec.TabIndex = 46;
            this.lblVlrPecasCabec.Text = "Vlr Das Peças";
            // 
            // txtVlrDasPecas
            // 
            this.txtVlrDasPecas.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtVlrDasPecas.Location = new System.Drawing.Point(597, 48);
            this.txtVlrDasPecas.Name = "txtVlrDasPecas";
            this.txtVlrDasPecas.Size = new System.Drawing.Size(130, 20);
            this.txtVlrDasPecas.TabIndex = 4;
            this.txtVlrDasPecas.TabStop = false;
            this.txtVlrDasPecas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaida
            // 
            this.txtSaida.Location = new System.Drawing.Point(297, 48);
            this.txtSaida.Mask = "99/99/99";
            this.txtSaida.Name = "txtSaida";
            this.txtSaida.PromptChar = ' ';
            this.txtSaida.Size = new System.Drawing.Size(116, 20);
            this.txtSaida.TabIndex = 2;
            // 
            // lblSaida
            // 
            this.lblSaida.AutoSize = true;
            this.lblSaida.Location = new System.Drawing.Point(294, 33);
            this.lblSaida.Name = "lblSaida";
            this.lblSaida.Size = new System.Drawing.Size(60, 13);
            this.lblSaida.TabIndex = 13;
            this.lblSaida.Text = "Data Saida";
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(151, 31);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(70, 13);
            this.lblEntrada.TabIndex = 12;
            this.lblEntrada.Text = "Data Entrada";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
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
            this.lblId.Size = new System.Drawing.Size(46, 13);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "Nº  O.S.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(925, 39);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "TooBar";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
            // gbValores
            // 
            this.gbValores.Controls.Add(this.btEncerrar);
            this.gbValores.Controls.Add(this.lblValorTitulo);
            this.gbValores.Controls.Add(this.txtValorTitulo);
            this.gbValores.Controls.Add(this.lblAbatimento);
            this.gbValores.Controls.Add(this.txtVlrAbatimento);
            this.gbValores.Controls.Add(this.lblAcrescimo);
            this.gbValores.Controls.Add(this.txtVlrAcrescimo);
            this.gbValores.Controls.Add(this.txtVencimento);
            this.gbValores.Controls.Add(this.label4);
            this.gbValores.Location = new System.Drawing.Point(12, 158);
            this.gbValores.Name = "gbValores";
            this.gbValores.Size = new System.Drawing.Size(888, 100);
            this.gbValores.TabIndex = 50;
            this.gbValores.TabStop = false;
            this.gbValores.Text = "Identificação";
            // 
            // btEncerrar
            // 
            this.btEncerrar.Location = new System.Drawing.Point(635, 51);
            this.btEncerrar.Name = "btEncerrar";
            this.btEncerrar.Size = new System.Drawing.Size(129, 23);
            this.btEncerrar.TabIndex = 50;
            this.btEncerrar.Text = "GRAVAR";
            this.btEncerrar.UseVisualStyleBackColor = true;
            this.btEncerrar.Click += new System.EventHandler(this.btEncerrar_Click);
            // 
            // lblValorTitulo
            // 
            this.lblValorTitulo.AutoSize = true;
            this.lblValorTitulo.Location = new System.Drawing.Point(467, 38);
            this.lblValorTitulo.Name = "lblValorTitulo";
            this.lblValorTitulo.Size = new System.Drawing.Size(60, 13);
            this.lblValorTitulo.TabIndex = 49;
            this.lblValorTitulo.Text = "Valor Titulo";
            // 
            // txtValorTitulo
            // 
            this.txtValorTitulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtValorTitulo.Location = new System.Drawing.Point(470, 54);
            this.txtValorTitulo.Name = "txtValorTitulo";
            this.txtValorTitulo.ReadOnly = true;
            this.txtValorTitulo.Size = new System.Drawing.Size(130, 20);
            this.txtValorTitulo.TabIndex = 5;
            this.txtValorTitulo.TabStop = false;
            this.txtValorTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAbatimento
            // 
            this.lblAbatimento.AutoSize = true;
            this.lblAbatimento.Location = new System.Drawing.Point(155, 37);
            this.lblAbatimento.Name = "lblAbatimento";
            this.lblAbatimento.Size = new System.Drawing.Size(78, 13);
            this.lblAbatimento.TabIndex = 47;
            this.lblAbatimento.Text = "Vlr  Abatimento";
            // 
            // txtVlrAbatimento
            // 
            this.txtVlrAbatimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtVlrAbatimento.Location = new System.Drawing.Point(158, 54);
            this.txtVlrAbatimento.Name = "txtVlrAbatimento";
            this.txtVlrAbatimento.Size = new System.Drawing.Size(130, 20);
            this.txtVlrAbatimento.TabIndex = 3;
            this.txtVlrAbatimento.TabStop = false;
            this.txtVlrAbatimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVlrAbatimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsDoubleEntry);
            this.txtVlrAbatimento.Leave += new System.EventHandler(this.txtVlrAbatimento_Leave);
            // 
            // lblAcrescimo
            // 
            this.lblAcrescimo.AutoSize = true;
            this.lblAcrescimo.Location = new System.Drawing.Point(312, 38);
            this.lblAcrescimo.Name = "lblAcrescimo";
            this.lblAcrescimo.Size = new System.Drawing.Size(71, 13);
            this.lblAcrescimo.TabIndex = 46;
            this.lblAcrescimo.Text = "Vlr Acrescimo";
            // 
            // txtVlrAcrescimo
            // 
            this.txtVlrAcrescimo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtVlrAcrescimo.Location = new System.Drawing.Point(315, 54);
            this.txtVlrAcrescimo.Name = "txtVlrAcrescimo";
            this.txtVlrAcrescimo.Size = new System.Drawing.Size(130, 20);
            this.txtVlrAcrescimo.TabIndex = 4;
            this.txtVlrAcrescimo.TabStop = false;
            this.txtVlrAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVlrAcrescimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsDoubleEntry);
            this.txtVlrAcrescimo.Leave += new System.EventHandler(this.txtVlrAbatimento_Leave);
            // 
            // txtVencimento
            // 
            this.txtVencimento.Location = new System.Drawing.Point(15, 54);
            this.txtVencimento.Mask = "99/99/99";
            this.txtVencimento.Name = "txtVencimento";
            this.txtVencimento.PromptChar = ' ';
            this.txtVencimento.Size = new System.Drawing.Size(116, 20);
            this.txtVencimento.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Data Vencimento";
            // 
            // FormEncerramento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 286);
            this.Controls.Add(this.gbValores);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbIdentificacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormEncerramento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encerramento O.S.";
            this.Load += new System.EventHandler(this.FormEncerramento_Load);
            this.gbIdentificacao.ResumeLayout(false);
            this.gbIdentificacao.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbValores.ResumeLayout(false);
            this.gbValores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbIdentificacao;
        private System.Windows.Forms.MaskedTextBox txtEntrada;
        private System.Windows.Forms.Label lblTotalCabec;
        private System.Windows.Forms.TextBox txtValorOS;
        private System.Windows.Forms.Label lblValorDeMaoDeObraCabec;
        private System.Windows.Forms.TextBox txtVlrMaoDeMaoDeObra;
        private System.Windows.Forms.Label lblVlrPecasCabec;
        private System.Windows.Forms.TextBox txtVlrDasPecas;
        private System.Windows.Forms.MaskedTextBox txtSaida;
        private System.Windows.Forms.Label lblSaida;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbCancelar;
        private System.Windows.Forms.GroupBox gbValores;
        private System.Windows.Forms.Label lblValorTitulo;
        private System.Windows.Forms.TextBox txtValorTitulo;
        private System.Windows.Forms.Label lblAbatimento;
        private System.Windows.Forms.TextBox txtVlrAbatimento;
        private System.Windows.Forms.Label lblAcrescimo;
        private System.Windows.Forms.TextBox txtVlrAcrescimo;
        private System.Windows.Forms.MaskedTextBox txtVencimento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btEncerrar;
    }
}