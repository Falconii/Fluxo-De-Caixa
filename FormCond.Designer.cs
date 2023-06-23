
namespace Fluxo_De_Caixa
{
    partial class FormCond
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
            this.PDF = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PDF
            // 
            this.PDF.Location = new System.Drawing.Point(62, 50);
            this.PDF.Name = "PDF";
            this.PDF.Size = new System.Drawing.Size(75, 23);
            this.PDF.TabIndex = 0;
            this.PDF.Text = "PDF";
            this.PDF.UseVisualStyleBackColor = true;
            this.PDF.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Fechar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormCond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PDF);
            this.Name = "FormCond";
            this.Text = "FormCond";
            this.Activated += new System.EventHandler(this.FormCond_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCond_FormClosed);
            this.Load += new System.EventHandler(this.FormCond_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PDF;
        private System.Windows.Forms.Button button2;
    }
}