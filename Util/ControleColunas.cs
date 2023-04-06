using Fluxo_De_Caixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Util
{
    public static class ControleColunas
    {
        public static List<Coluna> lsColunas = new List<Coluna>();
        public static DateTime? dataInicial = null;
        public static DateTime? dataFinal   = null;
        public static string Cnpj = "";

        public static void LoadColunas000()
        {
            Coluna obj = new Coluna();
            lsColunas.Clear();
            obj = new Coluna() { User = 0, Indice = 00, Nome = "ID", Tam = 80 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 01, Nome = "PLANILHA", Tam = 450 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 02, Nome = "SISTEMA", Tam = 80 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 03, Nome = "EMPRESA", Tam = 85 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 04, Nome = "EMPRESADESCRICAO", Tam = 85 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 05, Nome = "LOCAL", Tam = 85 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 06, Nome = "CNPJ", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 07, Nome = "EMPRESAUNID", Tam = 300 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 08, Nome = "NRO_LINHA", Tam = 85 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 09, Nome = "DTLANC", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 10, Nome = "DTNF", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 11, Nome = "NRO", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 12, Nome = "SERIE", Tam = 85 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 13, Nome = "UF", Tam = 50 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 14, Nome = "NR_ITEM", Tam = 85 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 15, Nome = "MATERIAL", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 16, Nome = "DESCRICAO", Tam = 400 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 17, Nome = "NCM", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 18, Nome = "UNID", Tam = 50 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 19, Nome = "CFOP", Tam = 50 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 20, Nome = "QTD", Tam = 150, Formatacao = "N4" , Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight}; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 21, Nome = "VLR_CONTABIL", Tam = 150 , Formatacao = "N4", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 22, Nome = "STI", Tam = 50 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 23, Nome = "BAS_ICMS", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 24, Nome = "PER_ICMS", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 25, Nome = "VLR_ICMS", Tam = 150, Formatacao = "N4", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 26, Nome = "STP", Tam = 50 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 27, Nome = "BAS_PIS", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 28, Nome = "PER_PIS", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 29, Nome = "VLR_PIS", Tam = 150, Formatacao = "N4", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 30, Nome = "STC", Tam = 50 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 31, Nome = "BAS_COF", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 32, Nome = "PER_COF", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 33, Nome = "VLR_COF", Tam = 150, Formatacao = "N4", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 34, Nome = "STIP", Tam = 50 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 35, Nome = "BAS_IPI", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 36, Nome = "PER_IPI", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 37, Nome = "VLR_IPI", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 38, Nome = "BAS_ICMS_ST", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 39, Nome = "PER_ICMS_ST", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 40, Nome = "VLR_ICMS_ST", Tam = 150, Formatacao = "N2", Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 41, Nome = "DTNFE", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 42, Nome = "DTCREDITO", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 43, Nome = "VLR_ECONOMICO_PIS", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 44, Nome = "VLR_OUTRO_PIS", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 45, Nome = "VLR_ECONOMICO_COFINS", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 46, Nome = "VLR_OUTRO_COFINS", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 47, Nome = "DTFCORRECAO", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 48, Nome = "VLR_ECONOMICO_PIS_CORRIGIDO", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 49, Nome = "VLR_OUTRO_PIS_CORRIGIDO", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 50, Nome = "VLR_ECONOMICO_COFINS_CORRIGIDO", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 51, Nome = "VLR_OUTRO_COFINS_CORRIGIDO", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 52, Nome = "METODO_PIS", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 53, Nome = "METODO_COFINS", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 54, Nome = "TAXA", Tam = 50 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 55, Nome = "DTCREDITO", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 56, Nome = "DTFCORRECAO", Tam = 120 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 57, Nome = "VLR_IPI", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 58, Nome = "VLR_IPI_CORRIGIDO", Tam = 150 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 59, Nome = "TAXA", Tam = 50 }; lsColunas.Add(obj);

        }

        public static void LoadColunas001()
        {
            Coluna obj = new Coluna();
            lsColunas.Clear();
            obj = new Coluna() { User = 0, Indice = 00, Nome = "CODIGO", Tam = 80 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 01, Nome = "RAZAO", Tam = 450 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 02, Nome = "TELEFONE", Tam = 80 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 03, Nome = "E-MAIL", Tam = 85 }; lsColunas.Add(obj);
            obj = new Coluna() { User = 0, Indice = 04, Nome = "CONTA", Tam = 85 }; lsColunas.Add(obj);
        }

    }
}
