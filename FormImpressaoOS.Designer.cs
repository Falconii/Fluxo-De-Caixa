﻿
namespace Fluxo_De_Caixa
{
    partial class FormImpressaoOS
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
            this.gbParametros = new System.Windows.Forms.GroupBox();
            this.txtInicial = new System.Windows.Forms.TextBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.txtVias = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btImprimir = new System.Windows.Forms.Button();
            this.lblOsInicial = new System.Windows.Forms.Label();
            this.lblOsFinal = new System.Windows.Forms.Label();
            this.lblVias = new System.Windows.Forms.Label();
            this.gbParametros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbParametros
            // 
            this.gbParametros.Controls.Add(this.lblVias);
            this.gbParametros.Controls.Add(this.lblOsFinal);
            this.gbParametros.Controls.Add(this.lblOsInicial);
            this.gbParametros.Controls.Add(this.txtVias);
            this.gbParametros.Controls.Add(this.txtFinal);
            this.gbParametros.Controls.Add(this.txtInicial);
            this.gbParametros.Location = new System.Drawing.Point(12, 22);
            this.gbParametros.Name = "gbParametros";
            this.gbParametros.Size = new System.Drawing.Size(395, 100);
            this.gbParametros.TabIndex = 0;
            this.gbParametros.TabStop = false;
            this.gbParametros.Text = "Parametros";
            // 
            // txtInicial
            // 
            this.txtInicial.Location = new System.Drawing.Point(16, 54);
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(100, 20);
            this.txtInicial.TabIndex = 0;
            this.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsDoubleEntry);
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(149, 54);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFinal.TabIndex = 1;
            this.txtFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsDoubleEntry);
            // 
            // txtVias
            // 
            this.txtVias.Location = new System.Drawing.Point(278, 54);
            this.txtVias.Name = "txtVias";
            this.txtVias.Size = new System.Drawing.Size(100, 20);
            this.txtVias.TabIndex = 2;
            this.txtVias.Text = "1";
            this.txtVias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsDoubleEntry);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(224, 143);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.Location = new System.Drawing.Point(332, 143);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(75, 23);
            this.btImprimir.TabIndex = 2;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // lblOsInicial
            // 
            this.lblOsInicial.AutoSize = true;
            this.lblOsInicial.Location = new System.Drawing.Point(16, 35);
            this.lblOsInicial.Name = "lblOsInicial";
            this.lblOsInicial.Size = new System.Drawing.Size(58, 13);
            this.lblOsInicial.TabIndex = 3;
            this.lblOsInicial.Text = "O.S. Inicial";
            // 
            // lblOsFinal
            // 
            this.lblOsFinal.AutoSize = true;
            this.lblOsFinal.Location = new System.Drawing.Point(146, 38);
            this.lblOsFinal.Name = "lblOsFinal";
            this.lblOsFinal.Size = new System.Drawing.Size(53, 13);
            this.lblOsFinal.TabIndex = 4;
            this.lblOsFinal.Text = "O.S. Final";
            // 
            // lblVias
            // 
            this.lblVias.AutoSize = true;
            this.lblVias.Location = new System.Drawing.Point(280, 38);
            this.lblVias.Name = "lblVias";
            this.lblVias.Size = new System.Drawing.Size(45, 13);
            this.lblVias.TabIndex = 5;
            this.lblVias.Text = "Nº  Vias";
            // 
            // FormImpressaoOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 178);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.gbParametros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormImpressaoOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impressão De O.S.";
            this.Load += new System.EventHandler(this.FormImpressaoOS_Load);
            this.gbParametros.ResumeLayout(false);
            this.gbParametros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParametros;
        private System.Windows.Forms.Label lblVias;
        private System.Windows.Forms.Label lblOsFinal;
        private System.Windows.Forms.Label lblOsInicial;
        private System.Windows.Forms.TextBox txtVias;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.TextBox txtInicial;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btImprimir;
    }
}