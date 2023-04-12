using System;

namespace Fluxo_De_Caixa.Models
{
    public class Documento
    {

        public int IdEmpresa { get; set; }
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Doc { get; set; }
        public string Serie { get; set; }
        public string Parcela { get; set; }
        public int Clifor { get; set; }
        public string Razao { get; set; }
        public Nullable<DateTime>  Emissao { get; set; }
        public Nullable<DateTime> Vencimento { get; set; }
        public double Valor { get; set; }
        public double Abatimento { get; set; }
        public double Juros { get; set; }
        public double VlrPago { get; set; }
        public double Saldo { get; set; }
        public string Obs { get; set; }
        public int UserInsert { get; set; }
        public int UserUpdate { get; set; }
        public string _Cod_Conta { get; set; }
        public string _Conta { get; set; }

        public Documento(int idEmpresa, int id, string tipo, string doc, string serie, string parcela, int clifor, string razao, DateTime? emissao, DateTime? vencimento, double valor, double abatimento, double juros, double vlrPago, double saldo, string obs, int userInsert, int userUpdate, string cod_Conta, string conta)
        {
            IdEmpresa = idEmpresa;
            Id = id;
            Tipo = tipo;
            Doc = doc;
            Serie = serie;
            Parcela = parcela;
            Clifor = clifor;
            Razao = razao;
            Emissao = emissao;
            Vencimento = vencimento;
            Valor = valor;
            Abatimento = abatimento;
            Juros = juros;
            VlrPago = vlrPago;
            Saldo = saldo;
            Obs = obs;
            UserInsert = userInsert;
            UserUpdate = userUpdate;
            _Cod_Conta = cod_Conta;
            _Conta = conta;
        }

        public Documento()
        {
            Zerar();
        }
             

        public void Zerar()
        {
            IdEmpresa = 1;
            Id = 0;
            Tipo = "";
            Doc = "";
            Serie = "";
            Parcela = "";
            Clifor = 0;
            Razao = "";
            Emissao = DateTime.Today;
            Vencimento = DateTime.Today;
            Valor = 0;
            Abatimento = 0;
            Juros = 0;
            VlrPago = 0;
            Saldo = 0;
            Obs = "";
            UserInsert = 0;
            UserUpdate = 0;
            _Cod_Conta = "";
            _Conta = "";
    }
    }
}
