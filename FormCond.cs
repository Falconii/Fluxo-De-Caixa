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

            daoCabOS daoCab = new daoCabOS();
            List<string> produtos = new List<string>();
            produtos.Add("Amortecedor da suspensão");
            produtos.Add("Anel de pistão");
            produtos.Add("Bomba elétrica de combustível para motores do Ciclo Otto");
            produtos.Add("Bronzina");
            produtos.Add("Buzina ou equipamento similar");
            produtos.Add("Lâmpada para veículos automotivos");
            produtos.Add("Pino e anel de trava (retenção)");
            produtos.Add("Pistão de liga leve de alumínio");
            produtos.Add("Baterias");
            produtos.Add("Terminal de direção");
            produtos.Add("Barra de direção");
            produtos.Add("Barra de ligação");
            produtos.Add("Terminal axial para veículos rodoviários automotores (componente da direção)");
            produtos.Add("Materiais de atrito para freios (lonas e pastilhas)");
            produtos.Add("Rodas automotivas");
            produtos.Add("Vidro de segurança laminado de para-brisas");
            produtos.Add("Vidro de segurança temperado");
            produtos.Add("Fluído de freio");
            produtos.Add("Catalisador");
            //Inclusao
            CabOS cab = new CabOS();
            cab.Id_Empresa = 1;
            cab.Id = 0;
            cab.Id_Cliente = 14;
            cab.Id_Carro = "BEE4R22";
            cab.Id_Cond = 0;
            cab.Horas_Servico = "07:25";
            cab.Km = 100000;
            cab.Obs = "OSBSERVAO IMPORTANTE";
            cab.Lucro = 100;
            cab.Mao_Obra =  "Sobre este item\n" +
                            "Organiza a montagem do seu quebra-cabeça\n " +
                            "Contém seis bandejas\n " +
                            "Armazena até duas mil peças\n " + 
                            "Número de jogadores: 1 ou mais ";
            cab.Mao_Obra_Vlr = 200;
            cab.Pecas_Vlr = 300;
            cab.User_Insert = 1;
            cab.User_Update = 0;

            List<DetOS> detalhes = new List<DetOS>();
            for (int x = 0; x < 19; x++)
            {
                DetOS det = new DetOS();
                det.Id_Empresa = 1;
                det.Id_Os = cab.Id;
                det.Item = x+1;
                det.Qtd = x * 2;
                det.Descricao = produtos[x];
                det.Valor = x * 2 + 1;
                det.User_Insert = 1;
                det.User_Update = 0;
                detalhes.Add(det);

            }
            //daoCab.SaveFullOs(cab, detalhes, "I");
            /*
               List<CabOS> os = new List<CabOS>();
               Console.WriteLine("Inicio....");
               os = daoCab.getAll(1, "");
               if (os.Count > 0)
               {
                   daoCab.DeleteFullOs(os[0]);
               }
               Console.WriteLine("Fim.....");
               */

            OsPDF osPDF = new OsPDF("", 7, 1);
            osPDF.ImprimirOS();

        }
    }
}
