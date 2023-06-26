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
            /*
            daoCabOS daoCab = new daoCabOS();
            daoDetOS daoDet = new daoDetOS();
            CabOS cab= new CabOS();
            cab.Id_Empresa = 1;
            cab.Id = 0;
            cab.Id_Cliente = 14;
            cab.Id_Carro = "BEE4R22";
            cab.Id_Cond = 0;
            cab.Horas_Servico = "07:25";
            cab.Km = 100000;
            cab.Obs = "OSBSERVAO IMPORTANTE";
            cab.Lucro = 100;
            cab.Mao_Obra = "JKLAJSKLAJSK LKJASLKJKLAJSL LKAJSKJ KJASKJAK KJASKJKA ";
            cab.Mao_Obra_Vlr = 200;
            cab.Pecas_Vlr = 300;
            cab.User_Insert = 1;
            cab.User_Update = 0;

            cab = daoCab.Insert(cab);

            if (cab != null)
            {
                List<DetOS> detalhes = new List<DetOS>();
                for (int x = 0; x < 15; x++)
                {
                    DetOS det = new DetOS();
                    det.Id_Empresa = 1;
                    det.Id_Os = cab.Id;
                    det.Item = x;
                    det.Qtd = x * 2;
                    det.Descricao = $"OLÁ SOU O ITEM {x}";
                    det.Valor = x * 2;
                    det.User_Insert = 1;
                    det.User_Update = 0;
                    detalhes.Add(det);
                }

                try
                {

                    detalhes.ForEach(det =>
                    {

                        DetOS reg = daoDet.Insert(det);

                        if (reg == null)
                        {
                            throw new Exception("Deu Merda...");
                        }

                    });
                }

                catch (Exception ex)
                {
                    MessageBox.Show("DEU ERRO...", "Atenção!");
                }
            }
            */
            OsPDF osPDF = new OsPDF("", 6, 1);
            osPDF.ImprimirOS();
        }
    }
}
