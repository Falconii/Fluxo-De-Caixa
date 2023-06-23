namespace Fluxo_De_Caixa
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automoveisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condPagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fluxoDeCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagarReceberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.janelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.documentosToolStripMenuItem,
            this.fluxoDeCaixaToolStripMenuItem,
            this.janelaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.janelaToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.fornecedoresToolStripMenuItem,
            this.contasToolStripMenuItem,
            this.automoveisToolStripMenuItem,
            this.condPagamentoToolStripMenuItem,
            this.usuáriosToolStripMenuItem,
            this.toolStripSeparator1,
            this.fimToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // fornecedoresToolStripMenuItem
            // 
            this.fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            this.fornecedoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fornecedoresToolStripMenuItem.Text = "Fornecedores";
            this.fornecedoresToolStripMenuItem.Click += new System.EventHandler(this.fornecedoresToolStripMenuItem_Click);
            // 
            // contasToolStripMenuItem
            // 
            this.contasToolStripMenuItem.Name = "contasToolStripMenuItem";
            this.contasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.contasToolStripMenuItem.Text = "Contas";
            this.contasToolStripMenuItem.Click += new System.EventHandler(this.contasToolStripMenuItem_Click);
            // 
            // automoveisToolStripMenuItem
            // 
            this.automoveisToolStripMenuItem.Name = "automoveisToolStripMenuItem";
            this.automoveisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.automoveisToolStripMenuItem.Text = "Automoveis";
            this.automoveisToolStripMenuItem.Click += new System.EventHandler(this.automoveisToolStripMenuItem_Click);
            // 
            // condPagamentoToolStripMenuItem
            // 
            this.condPagamentoToolStripMenuItem.Name = "condPagamentoToolStripMenuItem";
            this.condPagamentoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.condPagamentoToolStripMenuItem.Text = "Cond Pagamento";
            this.condPagamentoToolStripMenuItem.Click += new System.EventHandler(this.condPagamentoToolStripMenuItem_Click);
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            this.usuáriosToolStripMenuItem.Click += new System.EventHandler(this.usuáriosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // fimToolStripMenuItem
            // 
            this.fimToolStripMenuItem.Name = "fimToolStripMenuItem";
            this.fimToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fimToolStripMenuItem.Text = "Fim";
            this.fimToolStripMenuItem.Click += new System.EventHandler(this.FimToolStripMenuItem_Click);
            // 
            // documentosToolStripMenuItem
            // 
            this.documentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentosToolStripMenuItem1});
            this.documentosToolStripMenuItem.Name = "documentosToolStripMenuItem";
            this.documentosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.documentosToolStripMenuItem.Text = "Documentos";
            // 
            // documentosToolStripMenuItem1
            // 
            this.documentosToolStripMenuItem1.Name = "documentosToolStripMenuItem1";
            this.documentosToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.documentosToolStripMenuItem1.Text = "Documentos";
            this.documentosToolStripMenuItem1.Click += new System.EventHandler(this.documentosToolStripMenuItem1_Click);
            // 
            // fluxoDeCaixaToolStripMenuItem
            // 
            this.fluxoDeCaixaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem,
            this.pagarReceberToolStripMenuItem});
            this.fluxoDeCaixaToolStripMenuItem.Name = "fluxoDeCaixaToolStripMenuItem";
            this.fluxoDeCaixaToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.fluxoDeCaixaToolStripMenuItem.Text = "Fluxo De Caixa";
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.consultaToolStripMenuItem.Text = "Fluxo De Caixa";
            this.consultaToolStripMenuItem.Click += new System.EventHandler(this.consultaToolStripMenuItem_Click);
            // 
            // pagarReceberToolStripMenuItem
            // 
            this.pagarReceberToolStripMenuItem.Name = "pagarReceberToolStripMenuItem";
            this.pagarReceberToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pagarReceberToolStripMenuItem.Text = "Pagar/Receber";
            this.pagarReceberToolStripMenuItem.Click += new System.EventHandler(this.pagarReceberToolStripMenuItem_Click);
            // 
            // janelaToolStripMenuItem
            // 
            this.janelaToolStripMenuItem.Name = "janelaToolStripMenuItem";
            this.janelaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.janelaToolStripMenuItem.Text = "Janela";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem janelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fluxoDeCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagarReceberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automoveisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem condPagamentoToolStripMenuItem;
    }
}

