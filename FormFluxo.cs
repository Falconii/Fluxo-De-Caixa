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
    public partial class FormFluxo : Form
    {
        public ToolStripMenuItem menu { get; internal set; }

        public FormFluxo()
        {
            InitializeComponent();
        }

        private void FormFluxo_Load(object sender, EventArgs e)
        {

        }

        private void FormFluxo_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void FormFluxo_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
