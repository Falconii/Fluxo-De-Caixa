using System;

namespace Fluxo_De_Caixa.Util
{
    class ExceptionErroImportacao :  Exception
    {
        public ErrosImportacao Erros { get; set; }

        public ExceptionErroImportacao(
            string planilha,
            string linha,
            string campo,
            string valorCampo, 
            int tamanhoMax, 
            string obs)
        {
            Erros = new ErrosImportacao(planilha, linha, campo, valorCampo, tamanhoMax, obs);
        }
    }
}
