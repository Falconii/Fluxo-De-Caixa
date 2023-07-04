using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Util
{
    class Duplicata
    {
        public int Id_Empresa {get; set;}
        public int Os { get; set; }
        public  string Parcela { get; set; }
        public int Cod_Cliente { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }
        public string Obs { get; set; }

        public Duplicata(int id_Empresa, int os, string parcela, int cod_Cliente, DateTime emissao, DateTime vencimento, double valor, string obs)
        {
            Id_Empresa = id_Empresa;
            Os = os;
            Parcela = parcela;
            Cod_Cliente = cod_Cliente;
            Emissao = emissao;
            Vencimento = vencimento;
            Valor = valor;
            Obs = obs;
        }

        public void Zerar()
        {
            Id_Empresa = 1;
            Os = 0;
            Parcela = "";
            Cod_Cliente = 0;
            Emissao = DateTime.Now;
            Vencimento = DateTime.Now;
            Valor = 0;
            Obs = "";
        }
    }

}
