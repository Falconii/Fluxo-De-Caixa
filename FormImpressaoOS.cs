using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Util;
using System;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public partial class FormImpressaoOS : Form
    {

        int Inicial = 0;
        int Final = 0;
        int Vias = 0;
        public FormImpressaoOS(int inicial, int final, int vias)
        {
            InitializeComponent();
            this.Inicial = inicial;
            this.Final = final;
            this.Vias = vias;
            txtInicial.Text = this.Inicial.ToString();
            txtFinal.Text = this.Final.ToString();
            txtVias.Text = this.Vias.ToString();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string Validacao()
        {
            string retorno = "";

            if (txtInicial.Text.IntParse() == 0)
            {
                retorno += "Nro Da O.S. Inicial Inválido!\n";
            }
            if (txtFinal.Text.IntParse() == 0)
            {
                retorno += "Nro Da O.S. Final Inválido!\n";
            }
            if (txtVias.Text.IntParse() == 0)
            {
                retorno += "Nro De Vias Final Inválido!\n";
            }
            return retorno;
        }

        private void FormImpressaoOS_Load(object sender, EventArgs e)
        {

        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            string Erros = Validacao();
            if (Erros != "")
            {
                MessageBox.Show(Erros, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }
            else
            {

                Inicial = txtInicial.Text.IntParse();
                Final = txtFinal.Text.IntParse();
                Vias = txtVias.Text.IntParse();
                ImprimirOS();

                Close();
            }
        }

        private void IsDoubleEntry(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 44 && ((TextBox)sender).Text.IndexOf(",") != -1)
            {

                e.Handled = true;

                return;

            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {

                e.Handled = true;
            }

        }

        private void ImprimirOS()
        {


            OsPDF osPDF = new OsPDF("", Inicial, Final , Vias);

            osPDF.ImprimirOS();

        }
    }
}
