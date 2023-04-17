using System;

namespace Fluxo_De_Caixa.Models
{
    public class Fluxo
    {
        public Nullable<DateTime> doc_venciment { get; set; }
        public string doc_doc { get; set; }
        public string doc_serie { get; set; }
        public string doc_parcela { get; set; }
        public Nullable<DateTime> doc_emissao { get; set; }
        public int doc_clifor { get; set; }
        public string doc_razao { get; set; }
        public string _conta { get; set; }
        public double debito { get; set; }
        public double credito { get; set; }
        public double saldo { get; set; }
        public Fluxo(DateTime? doc_venciment, string doc_doc, string doc_serie, string doc_parcela, DateTime? doc_emissao, int doc_clifor, string doc_razao, string conta, double debito, double credito, double saldo)
        {
            this.doc_venciment = doc_venciment;
            this.doc_doc = doc_doc;
            this.doc_serie = doc_serie;
            this.doc_parcela = doc_parcela;
            this.doc_emissao = doc_emissao;
            this.doc_clifor = doc_clifor;
            this.doc_razao = doc_razao;
            this._conta = conta;
            this.debito = debito;
            this.credito = credito;
            this.saldo = saldo;
        }
        public Fluxo()
        {
            Zerar();
        }
        public void Zerar()
        {
            this.doc_venciment = null;
            this.doc_doc = "";
            this.doc_serie = "";
            this.doc_parcela = "";
            this.doc_emissao = null;
            this.doc_clifor = 0;
            this.doc_razao = "";
            this._conta = "";
            this.debito = 0;
            this.credito = 0;
            this.saldo = 0;
        }
    }
}
