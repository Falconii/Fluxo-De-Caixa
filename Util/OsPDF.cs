using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Util
{
    public class OsPDF
    {
        private string FileName = "";
        private int OsNumero = 0;
        private int Vias = 0;
        private DadosImpressao dadosImpressao = new DadosImpressao();

        public OsPDF(string fileName, int osNumero, int vias)
        {
            FileName = fileName;
            OsNumero = osNumero;
            Vias = vias;
        }

        public void ImprimirOS()
        {
            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {


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


                string CodigoBanco = "033-7";

                String NomeBanco = "BANCO SANTANDER";

                string LogoBanco = "C:\\LOGOS\\SANTANDER.PNG";

                string localdepagamento = "PAGÁVEL EM QUALQUER BANCO ATÉ O VENCIMENTO";

                string vencimento = "27/12/2064";

                string beneficiario = "MARIA MADALENA DA SILVA";

                string Agencia_Conta = "22222-90//92929292";

                string NossoNro = "1234567890-11";

                string DataDocumento = "12/12/2019";

                string NroDocumento = "909090900-A";

                string EspecieDoc = "DM";

                string Aceite = "NÃO";

                string DataProcessamento = "12/12/12";

                string Carteira = "COBRANÇA SIMPLES";

                string Especie = "R$";

                string Quantidade = "1.890,00";

                string Valor = "12.000,50";

                string ValorDocumento = "140.000,76";

                string Linha01 = "BANCO: NAO RECEBER APOS VENCIMENTO.";
                string Linha02 = "REF MESES:  07/2019 08/2019";
                string Linha03 = "VALORES EXPRESSOS EM REAIS";
                string Linha04 = "";
                string Linha05 = "";
                string Linha06 = "";

                int NroItem = 0;

                bool First = false;



                string nome = "MARCOS RENATO FALCONI";

                string endereco = "RUA MICHEL MASLJUR, 236";

                string cidade = "Campinas,SP";

                double offset = 0f;

                double linha = 10f;

                double AlturaLinhaBanco = 28f;

                double PosicaoReta = linha + AlturaLinhaBanco;

                double ColunaVencimenos = 440f;

                double ColunaNroBancario = 88f;

                double ColunaEspecieDoc = 176f;

                double ColunaAceite = 264f;

                double ColunaDataProcessamento = 352f;

                double ColunaEspecie = 146f;

                double ColunaQuantidade = 219f;

                double ColunaValor = 293f;

                double ColunaQtd = 30f;

                double ColunaDescricao = 80f;

                double ColunaPreco = 490f;

                double PosicaoInicial = 0f;

                double PosicaoFinal = 0f;

                //LayOut

                graphics.DrawRoundedRectangle(PdfSharp.Drawing.XPens.Black, 010, 010, page.Width - 20, page.Height - 20, 0, 0);


                //Ficha Do Caixa
                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 120, linha, 120, linha + AlturaLinhaBanco);
                //graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 120 + 60, linha, 120 + 60, linha + AlturaLinhaBanco);
                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                //Logo 
                graphics.DrawImage(PdfSharp.Drawing.XImage.FromFile(LogoBanco), 9, linha, 108.5, PosicaoReta - 9);
                //Nome Da Empresa
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                textFormatter.DrawString($"{dadosImpressao.EmpresaRazao}", FontNroBanco, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(140, linha+2 , page.Width-150, Font.Height));
                //Endereço
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString($"{dadosImpressao.getEnderecoCompleto()}", Font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(125, PosicaoReta - 10, 400, Font.Height));
                //Endereço
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                textFormatter.DrawString($"Tel.: {dadosImpressao.Telefone}", Font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(180, PosicaoReta - 10, 400, Font.Height));
                //Linha HUm
                linha += AlturaLinhaBanco;
                PosicaoReta = linha + AlturaLinhaBanco;

                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaVencimenos, linha, ColunaVencimenos, linha + AlturaLinhaBanco);
                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                //Cliente
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Nome Do Cliente", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 02, 250, FontSubTitulo.Height));
                textFormatter.DrawString(localdepagamento, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, PosicaoReta - 15, 300, FontSubTitulo.Height));

                //Data Entrada
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Data Entrada", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha + 02, 200, FontSubTitulo.Height));
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                textFormatter.DrawString("20/12/2019", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, PosicaoReta - 15, 140, FontSubTitulo.Height));

                //Linha 2
                linha += AlturaLinhaBanco;
                PosicaoReta = linha + AlturaLinhaBanco;
                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaVencimenos, linha, ColunaVencimenos, linha + AlturaLinhaBanco);
                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);

                //Beneficiario
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Endereço", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 02, 250, FontSubTitulo.Height));
                textFormatter.DrawString("Rua Pedro de lima jesus, 234 VL BRANDINA CEP 13034-180 CAMPINAS,SP", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, PosicaoReta - 15, 300, FontSubTitulo.Height));

                //Data Saida
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Data Saida", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha + 02, 200, FontSubTitulo.Height));
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                textFormatter.DrawString("99/55/55", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, PosicaoReta - 15, 140, FontSubTitulo.Height));



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
                textFormatter.DrawString("EDT-4208", FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, PosicaoReta - 15, 180, FontSubTitulo.Height));

                //MARCA
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Marca", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaNroBancario + 02, linha + 02, 250, FontSubTitulo.Height));
                textFormatter.DrawString(NroDocumento, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaNroBancario + 02, PosicaoReta - 15, 180, FontSubTitulo.Height));

                //MODELO
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Modelo", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaEspecieDoc + 02, linha + 02, 250, FontSubTitulo.Height));
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                textFormatter.DrawString(EspecieDoc, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaEspecieDoc + 02, PosicaoReta - 15, 090, FontSubTitulo.Height));

                //COR
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Cor", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaAceite + 02, linha + 02, 250, FontSubTitulo.Height));
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(Aceite, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaAceite + 02, PosicaoReta - 15, 090, FontSubTitulo.Height));

                //ANO
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Ano", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDataProcessamento + 02, linha + 02, 250, FontSubTitulo.Height));
                textFormatter.DrawString(DataProcessamento, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDataProcessamento + 02, PosicaoReta - 15, 090, FontSubTitulo.Height));

                //Horas serviços
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Horas de serviço", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha + 02, 200, FontSubTitulo.Height));
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                textFormatter.DrawString(NossoNro, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, PosicaoReta - 15, 140, FontSubTitulo.Height));


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
                textFormatter.DrawString(Carteira, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, PosicaoReta - 15, 180, FontSubTitulo.Height));

  
                //km
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Km", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha + 02, 200, FontSubTitulo.Height));
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                textFormatter.DrawString(ValorDocumento, FontDados, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, PosicaoReta - 15, 140, FontSubTitulo.Height));


                //Mao De Obra
                linha += AlturaLinhaBanco;
                PosicaoReta = linha + (AlturaLinhaBanco * 2);
                PosicaoInicial = PosicaoReta;
                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaVencimenos, linha, ColunaVencimenos, linha +( AlturaLinhaBanco * 2));
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Mão De Obra", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 02, 250, FontSubTitulo.Height));
                //Valor Mão de Obra
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Valor Mão De Obra", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaVencimenos + 02, linha + 02, 200, FontSubTitulo.Height));
                //Linha 01
                linha += FontSubTitulo.GetHeight();
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(Linha01, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));

                //Linha02
                linha += FontSubTitulo.GetHeight();
                textFormatter.DrawString(Linha02, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));

                //Linha03
                linha += FontSubTitulo.GetHeight();
                textFormatter.DrawString(Linha03, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));

                //Linha04
                linha += FontSubTitulo.GetHeight();
                textFormatter.DrawString(Linha04, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));

                //Linha05
                linha += FontSubTitulo.GetHeight();
                textFormatter.DrawString(Linha05, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));

                //Linha06
                linha += FontSubTitulo.GetHeight();
                textFormatter.DrawString(Linha06, FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, FontSubTitulo.Height));


                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);

                //Peças
                linha += FontSubTitulo.GetHeight();
                textFormatter.DrawString("PEÇAS", Font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(10 + 02, linha + 02, 400, Font.Height));


                //Produtos
                linha += (AlturaLinhaBanco * 0.5);
                PosicaoReta = linha + (AlturaLinhaBanco * 0.5);
                NroItem = 1;
                First = true;
                do
                {
                    if ( First) {

                        graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                        textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                        textFormatter.DrawString("ITEM", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha , ColunaQtd-12, FontSubTitulo.Height));
                        textFormatter.DrawString("QTD" , FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaQtd, linha , ColunaDescricao - ColunaQtd, FontSubTitulo.Height));
                        textFormatter.DrawString("DESCRIÇÃO", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDescricao, linha, ColunaPreco - ColunaDescricao, FontSubTitulo.Height));
                        textFormatter.DrawString("VALOR", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaPreco, linha, (page.Width-10)- ColunaPreco, FontSubTitulo.Height));
                        linha += (AlturaLinhaBanco * 0.5);
                        PosicaoReta = linha + (AlturaLinhaBanco * 0.5);
                        First = false;
                    };

                    graphics.DrawLine(PdfSharp.Drawing.XPens.Black, 10, PosicaoReta, page.Width - 10, PosicaoReta);
                    textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                    textFormatter.DrawString($"{NroItem}"  , FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(12, linha + 03, ColunaQtd-12, FontSubTitulo.Height));
                    textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                    textFormatter.DrawString($"999,999,999", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaQtd, linha + 03, ColunaDescricao-ColunaQtd-2, FontSubTitulo.Height));
                    textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                    textFormatter.DrawString($"KJSLKAJSKLAJSKLJAKLSJKLASJ", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaDescricao + 2, linha + 03, ColunaPreco - ColunaDescricao , FontSubTitulo.Height));
                    textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Right;
                    textFormatter.DrawString($"R$ 900,00", FontSubTitulo, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(ColunaPreco, linha + 03, (page.Width-10) - ColunaPreco-2 , FontSubTitulo.Height));
                    PosicaoFinal = PosicaoReta;
                    linha += (AlturaLinhaBanco * 0.5);
                    PosicaoReta = linha + (AlturaLinhaBanco * 0.5);
                    NroItem++;

                } while (PosicaoReta < page.Height-50);

                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaQtd, PosicaoInicial, ColunaQtd, PosicaoFinal);
                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaDescricao, PosicaoInicial, ColunaDescricao, PosicaoFinal);
                graphics.DrawLine(PdfSharp.Drawing.XPens.Black, ColunaPreco, PosicaoInicial, ColunaPreco, PosicaoFinal);

                doc.Save("C:\\LIXO\\TESTE.PDF");

                System.Diagnostics.Process.Start("C:\\LIXO\\TESTE.PDF");


                /*
                 * lixo
                 *      for (int x = 0; x < 2; x++)
                {
                    linha = (offset.CompareTo(0f) == 0 ? 50 : 0);
                    textFormatter.DrawString(nome, font, PdfSharp.Drawing.XBrushes.Red, new PdfSharp.Drawing.XRect(0, linha, 250, font.Height));
                    linha = offset + linha + font.Height;
                    textFormatter.DrawString(endereco, font, PdfSharp.Drawing.XBrushes.Red, new PdfSharp.Drawing.XRect(0, linha, 250, font.Height));
                    linha = offset + linha + font.Height;
                    textFormatter.DrawString(cidade, font, PdfSharp.Drawing.XBrushes.Red, new PdfSharp.Drawing.XRect(0, linha, 250, font.Height));
                    offset = 300f;
                }
                Console.WriteLine($"Largura: {page.Width} Altura: {page.Height}");

                graphics.DrawRoundedRectangle(PdfSharp.Drawing.XPens.Violet, 110,010,150,150,0,0);

                graphics.DrawRoundedRectangle(PdfSharp.Drawing.XPens.Violet, 261,010, 150, 150,0,0);

    */

            }
        }
    }
}
