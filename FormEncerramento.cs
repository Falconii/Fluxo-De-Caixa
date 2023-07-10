using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{


    public partial class FormEncerramento : Form
    {
        private int nroOS = 0;

        private CabOS cab = new CabOS();
        private Documento doc = new Documento();
        private double VlrTitulo = 0;
        private double VlrAbatimento = 0;
        private double VlrJuros = 0;
        private DateTime DataSaida;
        private DateTime DataVencimento;

        public FormEncerramento(int os)
        {
            InitializeComponent();
            nroOS = os;
        }

        private void FormEncerramento_Load(object sender, EventArgs e)
        {
           daoCabOS dao = new daoCabOS();

            cab = dao.Seek(1, nroOS);

            Atualizar();
        }

        private void Atualizar()
        {
            txtId.Text = cab.Id.ToString();
            txtEntrada.Text = cab.Entrada.ToString("dd/MM/yy");
            txtSaida.Text = DateTime.Now.ToString("dd/MM/yy");
            txtVlrMaoDeMaoDeObra.Text = string.Format("{0:0.00}", cab.Mao_Obra_Vlr);
            txtVlrDasPecas.Text = string.Format("{0:0.00}", cab.Pecas_Vlr);
            txtValorOS.Text = string.Format("{0:0.00}", cab._Total_OS);
            txtVencimento.Text = txtSaida.Text;
            txtValorOS.Text = string.Format("{0:0.00}", cab._Total_OS - VlrAbatimento + VlrJuros);
            txtVlrAbatimento.Text = string.Format("{0:0.00}",  VlrAbatimento );
            txtVlrAcrescimo.Text = string.Format("{0:0.00}", VlrJuros);
            txtValorTitulo.Text = string.Format("{0:0.00}", cab._Total_OS - VlrAbatimento + VlrJuros);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private string Validar()
        {
            string retorno = "";

            retorno += ValidaDatas();

            retorno += ValidarValores();

            return retorno;
        }
        private String ValidaDatas()
        {
            String cRetorno = "";

            bool dataValida;

            DateTime data;


            dataValida = DateTime.TryParseExact(txtSaida.Text, "dd/MM/yy", CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None, out data);

            if (!dataValida)
            {
                cRetorno += "Data Saida Inválida !! \n";
            }
            else
            {
                DataSaida = data;
            }

            dataValida = DateTime.TryParseExact(txtVencimento.Text, "dd/MM/yy", CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None, out data);

            if (!dataValida)
            {
                cRetorno += "Data Vencimento Inválida !! \n";
            }
            else
            {
                DataVencimento = data;
            }


            if (cRetorno == "")
            {
                if (DataSaida.CompareTo(cab.Entrada) < 0)
                {
                    cRetorno += "Data Saida Deverá Ser Posterior A Data De Entrada !! \n";
                }

                if (DataVencimento.CompareTo(DataSaida) < 0)
                {
                    cRetorno += "Data Vencimento Deverá Ser Posterior A Data De Saida !! \n";
                }

            }
            return cRetorno;
        }

        private string ValidarValores()
        {
            string retorno = "";

            VlrAbatimento = txtVlrAbatimento.Text.DoubleParse();
            VlrJuros = txtVlrAcrescimo.Text.DoubleParse();
            VlrTitulo = cab._Total_OS - VlrAbatimento + VlrJuros;
            txtVlrAbatimento.Text = string.Format("{0:0.00}", VlrAbatimento);
            txtVlrAcrescimo.Text = string.Format("{0:0.00}", VlrJuros);
            txtValorTitulo.Text = string.Format("{0:0.00}", VlrTitulo);

            if (VlrAbatimento < 0)
            {
                retorno += "O Valor Do Abatimento Não Poderá Ser Menor Que Zero !! \n";
            }

            if (VlrJuros < 0)
            {
                retorno += "O Valor Do Acrescimo Não Poderá Ser Menor Que Zero !! \n";
            }

            if (VlrTitulo < 0)
            {
                retorno += "O Valor Do Título Não Poderá Ser Menor Que Zero !! \n";
            }


            return retorno;
        }
        private void tbCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btEncerrar_Click(object sender, EventArgs e)
        {
            string erros = "";

            daoCabOS daoCab = new daoCabOS();

            daoDocumento daoDoc = new daoDocumento();

            erros = Validar();

            if (erros != "")
            {
                MessageBox.Show(erros, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            cab.Saida = DataSaida;

            doc = new Documento();

            doc.IdEmpresa = 1;
            doc.Id = 0;
            doc.Tipo = "R";
            doc.Doc = cab.Id.ToString("000000");
            doc.Serie = "001";
            doc.Parcela = "1";
            doc.Clifor = cab.Id_Cliente;
            doc.Razao = "";
            doc.Emissao = DataSaida;
            doc.Vencimento = DataVencimento;
            doc.Valor = VlrTitulo;
            doc.Abatimento = VlrAbatimento;
            doc.Juros = VlrJuros;
            doc.VlrPago = 0;
            doc.Saldo = VlrTitulo;
            doc.Obs = "";
            doc.UserInsert = cab.User_Update;;
            doc.UserUpdate = 0;

            

            try
            {

                daoCab.Update(cab);

                if (daoDoc.Insert(doc) == null)
                {
                    MessageBox.Show("Problemas Na Inclusão Do Domento.\nFavor Incluir Manualmente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    MessageBox.Show("Encerramento Da O.S. Feito Com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtVlrAbatimento_Leave(object sender, EventArgs e)
        {
            ValidarValores();
        }
    }
}
