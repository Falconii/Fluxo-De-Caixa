using Fluxo_De_Caixa.Models;
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
        public CabOS  cabec        = new CabOS();
        public List<DetOS> lsdetalhe = new List<DetOS>();
        public CarOS automovel = new CarOS();

        public DadosImpressao()
        {
            Zerar();
        }

        public DadosImpressao(CabOS cabec, List<DetOS> lsdetalhe, CarOS automovel)
        {
            this.cabec = cabec;
            this.lsdetalhe = lsdetalhe;
            this.automovel = automovel;
        }

        public string getEnderecoCompleto()
        {
            return $"{Endereco} {Bairro} {Cep}-{Cidade},{Estado}";
        }

        public void Zerar()
        {
            this.cabec     = new CabOS();
            this.lsdetalhe = new List<DetOS>();
            this.automovel = new CarOS();
        }
    }
}
