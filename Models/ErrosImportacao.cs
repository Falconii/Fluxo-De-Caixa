using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Util
{
    public class ErrosImportacao
    {
        public string  Planilha { get; set; }
        public string  Linha    { get; set; }
        public string  Campo { get; set; }
        public string  ValorCampo { get; set; }
        public int     TamanhoMax { get; set; }
        public string  Obs { get; set; }

        public ErrosImportacao(string planilha, string linha, string campo, string valorCampo, int tamanhoMax, string obs)
        {
            Planilha = planilha;
            Linha = linha;
            Campo = campo;
            ValorCampo = valorCampo;
            TamanhoMax = tamanhoMax;
            Obs = obs;
        }
    }
}
