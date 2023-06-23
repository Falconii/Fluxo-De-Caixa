using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Util
{
    public class DadosImpressao
    {
        public string EmpresaRazao = "GT-CAR CENTRO AUTOMOTIVO";
        public string Endereco     = "RUA DAS PERPÉTUAS, 18";
        public string Bairro       = "VL MIMOSA";
        public string Cep          = "13050-042";
        public string Cidade       = "CAMPINAS";
        public string Estado       = "SP";
        public string Telefone     = "(19)3269-1020";

        public string getEnderecoCompleto()
        {
            return $"{Endereco} {Bairro} {Cep}-{Cidade},{Estado}";
        }

    }
}
