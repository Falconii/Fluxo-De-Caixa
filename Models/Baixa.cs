using System;

namespace Fluxo_De_Caixa.Models
{
    public class Baixa
    {

        public int IdEmpresa { get; set; }
        public int Id { get; set; }
        public int Id_Doc { get; set; }
        public Nullable<DateTime>  Emissao { get; set; }
        public double Valor { get; set; }
        public string Obs { get; set; }
        public int UserInsert { get; set; }
        public int UserUpdate { get; set; }
        public string Doc_Tipo { get; set; }
        public string Doc_Doc { get; set; }
        public string Doc_Serie { get; set; }
        public string Doc_Parcela { get; set; }
        public int Doc_Clifor { get; set; }
        public string Doc_Razao { get; set; }
        public Nullable<DateTime> Doc_Emissao { get; set; }
        public Nullable<DateTime> Doc_Vencimento { get; set; }
        public double Doc_Valor { get; set; }
        public double Doc_Abatimento { get; set; }
        public double Doc_Juros { get; set; }
        public double Doc_VlrPago { get; set; }
        public double Doc_Saldo { get; set; }
        public string Doc_Obs { get; set; }
        public string Doc_Conta { get; set; }
        public string Doc_Con_Desc { get; set; }

        public Baixa(int idEmpresa, int id, int id_Doc, DateTime? emissao, double valor, string obs, int userInsert, int userUpdate, string doc_Tipo, string doc_Doc, string doc_Serie, string doc_Parcela, int doc_Clifor, string doc_Razao, DateTime? doc_Emissao, DateTime? doc_Vencimento, double doc_Valor, double doc_Abatimento, double doc_Juros, double doc_VlrPago, double doc_Saldo, string doc_Obs, string doc_Conta, string doc_Con_Desc)
        {
            IdEmpresa = idEmpresa;
            Id = id;
            Id_Doc = id_Doc;
            Emissao = emissao;
            Valor = valor;
            Obs = obs;
            UserInsert = userInsert;
            UserUpdate = userUpdate;
            Doc_Tipo = doc_Tipo;
            Doc_Doc = doc_Doc;
            Doc_Serie = doc_Serie;
            Doc_Parcela = doc_Parcela;
            Doc_Clifor = doc_Clifor;
            Doc_Razao = doc_Razao;
            Doc_Emissao = doc_Emissao;
            Doc_Vencimento = doc_Vencimento;
            Doc_Valor = doc_Valor;
            Doc_Abatimento = doc_Abatimento;
            Doc_Juros = doc_Juros;
            Doc_VlrPago = doc_VlrPago;
            Doc_Saldo = doc_Saldo;
            Doc_Obs = doc_Obs;
            Doc_Conta = doc_Conta;
            Doc_Con_Desc = doc_Con_Desc;
        }

        public Baixa()
        {
            Zerar();
        }
          

        public void Zerar()
        {
            IdEmpresa = 0;
            Id = 0;
            Id_Doc = 0;
            Emissao = null;
            Valor = 0;
            Obs = "";
            UserInsert = 0;
            UserUpdate = 0;
            Doc_Tipo = "";
            Doc_Doc = "";
            Doc_Serie = "";
            Doc_Parcela = "";
            Doc_Clifor = 0;
            Doc_Razao = "";
            Doc_Emissao = null;
            Doc_Vencimento = null;
            Doc_Valor = 0;
            Doc_Abatimento = 0;
            Doc_Juros = 0;
            Doc_VlrPago = 0;
            Doc_Saldo = 0;
            Doc_Obs = "";
            Doc_Conta ="";
            Doc_Con_Desc = "";
        }
    }
}
