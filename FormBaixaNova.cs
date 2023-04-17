using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public partial class FormBaixaNova : Form
    {
        private Documento documento = new Documento();

        public  DateTime Hoje = DateTime.Now;

        public double Valor = 0;

        public string Obs = "";

        public FormBaixaNova(Documento documento)
        {
            this.documento = documento;

            InitializeComponent();

        }

        private void FormBaixaNova_Load(object sender, EventArgs e)
        {
            txtObsLanc.CharacterCasing = CharacterCasing.Upper;
            txtObsLanc.MaxLength = 30;
            Atualiza();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string erros = "";

            erros = ValidarData();

            Valor = txtVlrLanc.Text.DoubleParse();

            if ( (Valor <= 0) || (Valor > documento.Saldo)){
                erros += "Valor Do Lançamento Incorreto! \n";
            }

            if (erros == "")
            {
                Obs = txtObsLanc.Text.Trim();

                DialogResult = DialogResult.OK;

                Close();
            } else
            {
                MessageBox.Show(erros, "Atenção!");
            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Atualiza()
        {
            txtId.Text = documento.Id.ToString();   
            txtDocumento.Text = documento.Tipo;
            txtSerie.Text = documento.Serie;
            txtParcela.Text = documento.Parcela;
            txtValor.Text = string.Format("{0:0.00}", documento.Valor);
            txtAbatimento.Text = string.Format("{0:0.00}", documento.Abatimento);
            txtJuros.Text = string.Format("{0:0.00}", documento.Juros);
            txtVlrPago.Text = string.Format("{0:0.00}", documento.VlrPago);
            txtSaldo.Text = string.Format("{0:0.00}", documento.Saldo);

            txtPagamento.Text = Hoje.ToString("dd/MM/yy"); 
            txtVlrLanc.Text   = string.Format("{0:0.00}", documento.Saldo);
            txtObsLanc.Text = "";  
        }


        private String ValidarData()
        {
            String cRetorno = "";

            bool dataValida;

            DateTime data;

            dataValida = DateTime.TryParseExact(txtPagamento.Text, "dd/MM/yy", CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None, out data);

            if (!dataValida)
            {
                cRetorno += "Data Do Lançamento Inválida !! \n";
            } else
            {
                Hoje = data;

                if (data.CompareTo(documento.Emissao) < 0)
                {
                    cRetorno += "Data Do Lançamento Anterior A Data De Emissão !! \n";
                }

            }

            return cRetorno;
        }
    }
}
