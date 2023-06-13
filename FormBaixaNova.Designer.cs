
namespace Fluxo_De_Caixa
{
    partial class FormBaixaNova
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
            this.btOK = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
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
            this.gbLancamento = new System.Windows.Forms.GroupBox();
            this.txtObsLanc = new System.Windows.Forms.TextBox();
            this.txtVlrLanc = new System.Windows.Forms.TextBox();
            this.lblVlrLanc = new System.Windows.Forms.Label();
            this.txtPagamento = new System.Windows.Forms.MaskedTextBox();
            this.lblPagamento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbIdentificacao.SuspendLayout();
            this.gbSenha.SuspendLayout();
            this.gbLancamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(642, 352);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "Gravar";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(749, 352);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.button2_Click);
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
            this.gbIdentificacao.Location = new System.Drawing.Point(12, 12);
            this.gbIdentificacao.Name = "gbIdentificacao";
            this.gbIdentificacao.Size = new System.Drawing.Size(811, 95);
            this.gbIdentificacao.TabIndex = 2;
            this.gbIdentificacao.TabStop = false;
            this.gbIdentificacao.Text = "Identificação";
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
            this.txtParcela.Enabled = false;
            this.txtParcela.Location = new System.Drawing.Point(668, 38);
            this.txtParcela.Name = "txtParcela";
            this.txtParcela.Size = new System.Drawing.Size(130, 20);
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
            this.txtSerie.Enabled = false;
            this.txtSerie.Location = new System.Drawing.Point(496, 38);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(135, 20);
            this.txtSerie.TabIndex = 4;
            // 
            // cbTipo
            // 
            this.cbTipo.Enabled = false;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "RECEBER",
            "PAGAR"});
            this.cbTipo.Location = new System.Drawing.Point(146, 38);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(121, 21);
            this.cbTipo.TabIndex = 2;
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
            this.txtDocumento.Enabled = false;
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
            this.txtId.Enabled = false;
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
            this.gbSenha.Location = new System.Drawing.Point(12, 124);
            this.gbSenha.Name = "gbSenha";
            this.gbSenha.Size = new System.Drawing.Size(811, 100);
            this.gbSenha.TabIndex = 5;
            this.gbSenha.TabStop = false;
            this.gbSenha.Text = "Valores";
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
            this.txtVlrPago.Enabled = false;
            this.txtVlrPago.Location = new System.Drawing.Point(501, 50);
            this.txtVlrPago.Name = "txtVlrPago";
            this.txtVlrPago.ReadOnly = true;
            this.txtVlrPago.Size = new System.Drawing.Size(130, 20);
            this.txtVlrPago.TabIndex = 14;
            this.txtVlrPago.TabStop = false;
            this.txtVlrPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Location = new System.Drawing.Point(668, 50);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(130, 20);
            this.txtSaldo.TabIndex = 15;
            this.txtSaldo.TabStop = false;
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.txtJuros.Enabled = false;
            this.txtJuros.Location = new System.Drawing.Point(327, 50);
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.Size = new System.Drawing.Size(130, 20);
            this.txtJuros.TabIndex = 13;
            this.txtJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.txtAbatimento.Enabled = false;
            this.txtAbatimento.Location = new System.Drawing.Point(166, 50);
            this.txtAbatimento.Name = "txtAbatimento";
            this.txtAbatimento.Size = new System.Drawing.Size(130, 20);
            this.txtAbatimento.TabIndex = 12;
            this.txtAbatimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValor
            // 
            this.txtValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtValor.Enabled = false;
            this.txtValor.Location = new System.Drawing.Point(13, 50);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(130, 20);
            this.txtValor.TabIndex = 11;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // gbLancamento
            // 
            this.gbLancamento.Controls.Add(this.label1);
            this.gbLancamento.Controls.Add(this.txtObsLanc);
            this.gbLancamento.Controls.Add(this.txtVlrLanc);
            this.gbLancamento.Controls.Add(this.lblVlrLanc);
            this.gbLancamento.Controls.Add(this.txtPagamento);
            this.gbLancamento.Controls.Add(this.lblPagamento);
            this.gbLancamento.Location = new System.Drawing.Point(12, 246);
            this.gbLancamento.Name = "gbLancamento";
            this.gbLancamento.Size = new System.Drawing.Size(811, 100);
            this.gbLancamento.TabIndex = 6;
            this.gbLancamento.TabStop = false;
            this.gbLancamento.Text = "Lançamento";
            // 
            // txtObsLanc
            // 
            this.txtObsLanc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObsLanc.Location = new System.Drawing.Point(313, 54);
            this.txtObsLanc.Name = "txtObsLanc";
            this.txtObsLanc.Size = new System.Drawing.Size(485, 20);
            this.txtObsLanc.TabIndex = 43;
            // 
            // txtVlrLanc
            // 
            this.txtVlrLanc.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtVlrLanc.Location = new System.Drawing.Point(153, 54);
            this.txtVlrLanc.Name = "txtVlrLanc";
            this.txtVlrLanc.Size = new System.Drawing.Size(130, 20);
            this.txtVlrLanc.TabIndex = 41;
            this.txtVlrLanc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVlrLanc
            // 
            this.lblVlrLanc.AutoSize = true;
            this.lblVlrLanc.Location = new System.Drawing.Point(150, 38);
            this.lblVlrLanc.Name = "lblVlrLanc";
            this.lblVlrLanc.Size = new System.Drawing.Size(31, 13);
            this.lblVlrLanc.TabIndex = 42;
            this.lblVlrLanc.Text = "Valor";
            // 
            // txtPagamento
            // 
            this.txtPagamento.Location = new System.Drawing.Point(14, 54);
            this.txtPagamento.Mask = "99/99/9999";
            this.txtPagamento.Name = "txtPagamento";
            this.txtPagamento.PromptChar = ' ';
            this.txtPagamento.Size = new System.Drawing.Size(116, 20);
            this.txtPagamento.TabIndex = 40;
            // 
            // lblPagamento
            // 
            this.lblPagamento.AutoSize = true;
            this.lblPagamento.Location = new System.Drawing.Point(13, 39);
            this.lblPagamento.Name = "lblPagamento";
            this.lblPagamento.Size = new System.Drawing.Size(87, 13);
            this.lblPagamento.TabIndex = 39;
            this.lblPagamento.Text = "Data Pagamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Observação";
            // 
            // FormBaixaNova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(836, 387);
            this.Controls.Add(this.gbLancamento);
            this.Controls.Add(this.gbSenha);
            this.Controls.Add(this.gbIdentificacao);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btOK);
            this.Name = "FormBaixaNova";
            this.Text = "Nova Baixa";
            this.Load += new System.EventHandler(this.FormBaixaNova_Load);
            this.gbIdentificacao.ResumeLayout(false);
            this.gbIdentificacao.PerformLayout();
            this.gbSenha.ResumeLayout(false);
            this.gbSenha.PerformLayout();
            this.gbLancamento.ResumeLayout(false);
            this.gbLancamento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.GroupBox gbIdentificacao;
        private System.Windows.Forms.Label lblParcela;
        private System.Windows.Forms.TextBox txtParcela;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.GroupBox gbSenha;
        private System.Windows.Forms.Label lblVlrPago;
        private System.Windows.Forms.TextBox txtVlrPago;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label lblJuros;
        private System.Windows.Forms.TextBox txtJuros;
        private System.Windows.Forms.Label lblAbatimento;
        private System.Windows.Forms.TextBox txtAbatimento;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.GroupBox gbLancamento;
        private System.Windows.Forms.TextBox txtObsLanc;
        private System.Windows.Forms.TextBox txtVlrLanc;
        private System.Windows.Forms.Label lblVlrLanc;
        private System.Windows.Forms.MaskedTextBox txtPagamento;
        private System.Windows.Forms.Label lblPagamento;
        private System.Windows.Forms.Label label1;
    }
}