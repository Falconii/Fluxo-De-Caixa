using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Models;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fluxo_De_Caixa.Util
{
    public class OsPDF
    {
        private string FileName = "";
        private int OsInicial = 0;
        private int OsFinal = 0;
        private int OsNumero = 0;
        private int Vias = 0;
        private DadosImpressao dadosImpressao = new DadosImpressao();
        private CabOS cab = new CabOS();
        List<DetOS> detalhes = new List<DetOS>();


        public OsPDF(string fileName, int osInicial,int osFinal, int vias)
        {
            FileName = fileName;
            OsInicial  = osInicial;
            OsFinal = osFinal;
            Vias = vias;
        }

        private void getOS(int nro)
        {
            
            daoCabOS dao = new daoCabOS();
            cab = dao.Seek(1,nro);
            daoDetOS det = new daoDetOS();
            detalhes = det.getAll(0, nro.ToString());
            
        }
        public void ImprimirOS()
        {
            bool Imprimiu = false;

            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

            string Logo = $"{path}\\LOGO.PNG";

            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {

                for (int os = OsInicial; os <= OsFinal; os++)
                {

                    getOS(os);

                    if (cab == null) continue;

                    for (int via = 1; via <= Vias; via++)
                    {

                        Imprimiu = true;

                        var page = doc.AddPage();

                        page.Orientation = PdfSharp.PageOrientation.Portrait;

                        page.Size = PdfSharp.PageSize.A4;


                        var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);


                        var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);

                        var Font = new PdfSharp.Drawing.XFont("Arial", 08, PdfSharp.Drawing.XFontStyle.Regular);

                        var FontSubTitulo = new PdfSharp.Drawing.XFont("Courier", 07, PdfSharp.Drawing.XFontStyle.Regular);

                        var FontDados = new PdfSharp.Drawing.XFont("Courier", 07, PdfSharp.Drawing.XFontStyle.Bold);

                        var FontNroBanco = new PdfSharp.Drawing.XFont("Arial", 10, PdfSharp.Drawing.XFontStyle.Bold);

                        var FontEan13 = new PdfSharp.Drawing.XFont("EAN-13", 10, PdfSharp.Drawing.XFontStyle.Regular);


                        int NroItem = 0;

                        bool First = false;




                        double linha = 10f;

                        double AlturaLinhaBanco = 28f;

                        double PosicaoReta = linha + AlturaLinhaBanco;

                        double ColunaVencimenos = 440f;

                        double ColunaNroBancario = 88f;

                        double ColunaEspecieDoc = 176f;

                        double ColunaAceite = 264f;

                        double ColunaDataProcessamento = 352f;

                        double ColunaQtd = 30f;

                        double ColunaDescricao = 80f;

                        double ColunaPreco = 490f;

                        double PosicaoInicial = 0f;

                        double PosicaoFinal = 0f;

                        double PosicaoFinalTotais = 0f;

                        //LayOut

                        graphics.DrawRoundedRectangle(PdfSharp.Drawing.XPens.Black, 010, 010, page.Width - 20, page.Height - 20, 0, 0);


                        //Ficha Do Caixa
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 80, linha, 80, linha + (AlturaLinhaBanco * 2));
                        //graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 120 + 60, linha, 120 + 60, linha + AlturaLinhaBanco);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 80, PosicaoReta, page.Width - 10, PosicaoReta);

                        //Logo 
                        graphics.DrawImage(PdfSharp.Drawing.XImage.FromFile(Logo), 22, linha + 3, 50, 50);
                        //Nome Da Empresa
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                        textFormatter.DrawString($"{dadosImpressao.EmpresaRazao}", FontNroBanco, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(115, linha + 2, page.Width - 150, Font.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString($"O.S. N° {cab.Id.ToString("000000")}", FontNroBanco, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(510, linha + 2, 150, Font.Height));
                        //Endereço
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString($"{dadosImpressao.getEnderecoCompleto()}", Font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(82, PosicaoReta - 10, 400, Font.Height));
                        //Telefone
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString($"Tel.: {dadosImpressao.Telefone}", Font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(180, PosicaoReta - 10, 400, Font.Height));
                        //Linha HUm
                        linha += AlturaLinhaBanco;
                        PosicaoReta = linha + AlturaLinhaBanco;

                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaVencimenos, linha, ColunaVencimenos, linha + AlturaLinhaBanco);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaDataProcessamento, linha, ColunaDataProcessamento, linha + AlturaLinhaBanco);
                        //Cliente
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Nome Do Cliente", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(82, linha + 02, 250, FontSubTitulo.Height));
                        textFormatter.DrawString(cab.Cli_Razao, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(82, PosicaoReta - 15, 300, FontSubTitulo.Height));
                        //Telefone
                        textFormatter.DrawString("Telefone", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDataProcessamento + 2, linha + 02, 60, FontSubTitulo.Height));
                        textFormatter.DrawString(cab.Cli_Tel1, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDataProcessamento + 2, PosicaoReta - 15, 60, FontSubTitulo.Height));

                        //Data Entrada
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Data Entrada", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha + 02, 200, FontSubTitulo.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString(cab.Entrada.ToString("dd/MM/yyyy"), FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, PosicaoReta - 15, 140, FontSubTitulo.Height));

                        //Linha 2
                        linha += AlturaLinhaBanco;
                        PosicaoReta = linha + AlturaLinhaBanco;
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaVencimenos, linha, ColunaVencimenos, linha + AlturaLinhaBanco);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);

                        //Endereço
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Endereço", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 02, 250, FontSubTitulo.Height));
                        textFormatter.DrawString($"{cab.Cli_Endereco.Trim()},{cab.Cli_Nro.Trim()} {cab.Cli_Bairro.Trim()} - CEP: {cab.Cli_Cep} {cab.Cli_Cidade.Trim()},{cab.Cli_Uf}", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, PosicaoReta - 15, 300, FontSubTitulo.Height));

                        //Data Saida
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Data Saida", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha + 02, 200, FontSubTitulo.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString(cab.Saida == null ? "" : cab.Saida?.ToString("dd/MM/yyyy"), FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, PosicaoReta - 15, 140, FontSubTitulo.Height));



                        linha += AlturaLinhaBanco;
                        PosicaoReta = linha + AlturaLinhaBanco;
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaVencimenos, linha, ColunaVencimenos, linha + AlturaLinhaBanco);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaNroBancario, linha, ColunaNroBancario, linha + AlturaLinhaBanco);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaEspecieDoc, linha, ColunaEspecieDoc, linha + AlturaLinhaBanco);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaAceite, linha, ColunaAceite, linha + AlturaLinhaBanco);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaDataProcessamento, linha, ColunaDataProcessamento, linha + AlturaLinhaBanco);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);

                        //PLACA
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Placa", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 02, 250, FontSubTitulo.Height));
                        textFormatter.DrawString($"{cab.Car_Placa}", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, PosicaoReta - 15, 180, FontSubTitulo.Height));

                        //MARCA
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Marca", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaNroBancario + 02, linha + 02, 250, FontSubTitulo.Height));
                        textFormatter.DrawString($"{cab.Marca_Descricao}", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaNroBancario + 02, PosicaoReta - 15, 180, FontSubTitulo.Height));

                        //MODELO
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Modelo", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaEspecieDoc + 02, linha + 02, 250, FontSubTitulo.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString($"{cab.Car_Modelo}", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaEspecieDoc + 02, PosicaoReta - 15, 090, FontSubTitulo.Height));

                        //COR
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Cor", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaAceite + 02, linha + 02, 250, FontSubTitulo.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString($"{cab.Car_Cor}", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaAceite + 02, PosicaoReta - 15, 090, FontSubTitulo.Height));

                        //ANO
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Ano", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDataProcessamento + 02, linha + 02, 250, FontSubTitulo.Height));
                        textFormatter.DrawString($"{cab.Car_Ano}", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDataProcessamento + 02, PosicaoReta - 15, 090, FontSubTitulo.Height));

                        //Horas serviços
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Horas de serviço", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha + 02, 200, FontSubTitulo.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString($"{cab.Horas_Servico}", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, PosicaoReta - 15, 140, FontSubTitulo.Height));


                        linha += AlturaLinhaBanco;
                        PosicaoReta = linha + AlturaLinhaBanco;
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaVencimenos, linha, ColunaVencimenos, linha + AlturaLinhaBanco);
                        //graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaEspecie, linha, ColunaEspecie, linha + AlturaLinhaBanco);
                        //graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaQuantidade, linha, ColunaQuantidade, linha + AlturaLinhaBanco);
                        //graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaValor, linha, ColunaValor, linha + AlturaLinhaBanco);

                        //CARTEIRA
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Observação", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 02, 250, FontSubTitulo.Height));
                        textFormatter.DrawString($"{cab.Obs}", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, PosicaoReta - 15, 180, FontSubTitulo.Height));


                        //km
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Km", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha + 02, 200, FontSubTitulo.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString($"{cab.Km}", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, PosicaoReta - 15, 140, FontSubTitulo.Height));


                        //Mao De Obra
                        linha += AlturaLinhaBanco;
                        PosicaoReta = linha + (AlturaLinhaBanco / 2);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("MÃO DE OBRA", Font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 03, 250, Font.Height));
                        //Inicio Mão de Obra
                        linha += AlturaLinhaBanco / 2;
                        //PosicaoReta = linha + (AlturaLinhaBanco * 2);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaPreco, linha, ColunaPreco, linha + (AlturaLinhaBanco * 2));

                        //Valor Mão de Obra
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("Descrição", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 02, 250, FontSubTitulo.Height));
                        textFormatter.DrawString("Valor Mão De Obra", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaPreco + 02, linha + 02, (page.Width - 10) - ColunaPreco, FontSubTitulo.Height));
                        //Linha 01
                        linha += FontSubTitulo.GetHeight();
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Justify;
                        textFormatter.DrawString($"{cab.Mao_Obra}", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, ColunaPreco - 14, FontSubTitulo.Height * 6));

                        //Linha02
                        linha += FontSubTitulo.GetHeight();
                        //textFormatter.DrawString(Linha02, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));

                        //Linha03
                        linha += FontSubTitulo.GetHeight();
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString($"{cab.Mao_Obra_Vlr.ToString("##,##0.00")}", Font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha, 140, Font.Height));

                        //Linha04
                        linha += FontSubTitulo.GetHeight();
                        //textFormatter.DrawString(Linha04, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));

                        //Linha05
                        linha += FontSubTitulo.GetHeight();
                        //textFormatter.DrawString(Linha05, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));

                        //Linha06
                        linha += FontSubTitulo.GetHeight();
                        PosicaoReta = linha + FontSubTitulo.GetHeight();
                        //textFormatter.DrawString(Linha06, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));


                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);

                        //Peças
                        linha += AlturaLinhaBanco / 2;
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                        textFormatter.DrawString("PEÇAS", Font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha - 2, page.Width - 20, Font.Height));
                        linha += Font.Height;
                        PosicaoReta = linha;
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                        PosicaoInicial = PosicaoReta;

                        //Produtos
                        linha += (AlturaLinhaBanco * 0.5);
                        PosicaoReta = linha + (AlturaLinhaBanco * 0.5);
                        NroItem = 1;
                        First = true;
                        do
                        {
                            if (First)
                            {

                                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                                textFormatter.DrawString("ITEM", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha, ColunaQtd - 12, FontSubTitulo.Height));
                                textFormatter.DrawString("QTD", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaQtd, linha, ColunaDescricao - ColunaQtd, FontSubTitulo.Height));
                                textFormatter.DrawString("DESCRIÇÃO", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDescricao, linha, ColunaPreco - ColunaDescricao, FontSubTitulo.Height));
                                textFormatter.DrawString("VALOR", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaPreco, linha, (page.Width - 10) - ColunaPreco, FontSubTitulo.Height));
                                linha += (AlturaLinhaBanco * 0.5);
                                PosicaoReta = linha + (AlturaLinhaBanco * 0.5);
                                First = false;
                            };

                            graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                            textFormatter.DrawString($"{NroItem}", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 03, ColunaQtd - 12, FontSubTitulo.Height));
                            if (NroItem - 1 < detalhes.Count)
                            {
                                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                                textFormatter.DrawString(detalhes[NroItem - 1].Qtd.ToString("##,##0.###"), FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaQtd, linha + 03, ColunaDescricao - ColunaQtd - 2, FontSubTitulo.Height));
                                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                                textFormatter.DrawString(detalhes[NroItem - 1].Descricao, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDescricao + 2, linha + 03, ColunaPreco - ColunaDescricao, FontSubTitulo.Height));
                                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                                textFormatter.DrawString(detalhes[NroItem - 1].Valor.ToString("##,##0.00"), FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaPreco, linha + 03, (page.Width - 10) - ColunaPreco - 2, FontSubTitulo.Height));
                            }

                            PosicaoFinal = PosicaoReta;
                            PosicaoFinalTotais = PosicaoReta;
                            linha += (AlturaLinhaBanco * 0.5);
                            PosicaoReta = linha + (AlturaLinhaBanco * 0.5);
                            NroItem++;

                        } while (PosicaoReta < page.Height - 100);


                        //Total das Peças
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);


                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString("TOTAL DAS PEÇAS", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDescricao + 2, linha + 03, ColunaPreco - ColunaDescricao - 5, FontSubTitulo.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString(cab.Pecas_Vlr.ToString("###,##0.00"), FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaPreco, linha + 03, (page.Width - 10) - ColunaPreco - 3, FontSubTitulo.Height));

                        PosicaoFinal = PosicaoReta;
                        linha += (AlturaLinhaBanco * 0.5);
                        PosicaoReta = linha + (AlturaLinhaBanco * 0.5);


                        //Total da OS
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);


                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString("TOTAL DA O.S.", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDescricao + 2, linha + 03, ColunaPreco - ColunaDescricao - 5, FontSubTitulo.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                        textFormatter.DrawString(cab._Total_OS.ToString("###,##0.00"), FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaPreco, linha + 03, (page.Width - 10) - ColunaPreco - 2, FontSubTitulo.Height));

                        PosicaoFinal = PosicaoReta;
                        linha += (AlturaLinhaBanco * 0.5);
                        PosicaoReta = linha + (AlturaLinhaBanco * 0.5);


                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaQtd, PosicaoInicial, ColunaQtd, PosicaoFinalTotais);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaDescricao, PosicaoInicial, ColunaDescricao, PosicaoFinalTotais);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaPreco, PosicaoInicial, ColunaPreco, PosicaoFinal);


                        linha += (AlturaLinhaBanco / 2) + 10;
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                        textFormatter.DrawString("Assinatura Do Cliente", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12 + 50, linha + 03, 200, FontSubTitulo.Height));
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                        textFormatter.DrawString("Pago", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDataProcessamento + 30, linha + 03, 200, FontSubTitulo.Height));

                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 12 + 50, linha - 2, 12 + 50 + 200, linha - 2);
                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaDataProcessamento + 50, linha - 2, ColunaDataProcessamento + 200, linha - 2);
                    }

                }

                if (Imprimiu)
                {
                    doc.Save(FileName);

                    System.Diagnostics.Process.Start(FileName);

                } else
                {
                    DialogResult resultado = MessageBox.Show("Nenhuma O.S. Encontrada!", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
               

            }
        }
    }
}
