using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public partial class FormCond : Form
    {

        Visoes visao = Visoes.Browser;

        Cond cond = new Cond();

        int Ordenacao = 0; //CODIGO 

        string proprietario = "Cond. Pagto";
        public ToolStripMenuItem menu { get; internal set; }

        public FormCond()
        {
            InitializeComponent();
        }

        private void FormCond_Load(object sender, EventArgs e)
        {

        }

        private void FormCond_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormCond_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            OsPDF osPDF = new OsPDF("", 1, 1);
            osPDF.ImprimirOS();
        }
    }
}
