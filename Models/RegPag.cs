using System;

namespace Fluxo_De_Caixa.Models
{
    public class RegPag
    {
        public Nullable<DateTime> doc_venciment { get; set; }
        public string doc_doc { get; set; }
        public string doc_serie { get; set; }
        public string doc_parcela { get; set; }
        public Nullable<DateTime> doc_emissao { get; set; }
        public int doc_clifor { get; set; }
        public string doc_razao { get; set; }
        public string _conta { get; set; }
        public string doc_obs { get; set; }
        public double doc_valor { get; set; }
        public double doc_abatimento { get; set; }
        public double doc_juros { get; set; }
        public double doc_saldo { get; set; }
        public double total { get; set; }
        public RegPag(DateTime? doc_venciment, string doc_doc, string doc_serie, string doc_parcela, DateTime? doc_emissao, int doc_clifor, string doc_razao, string conta, string doc_obs, double doc_valor, double doc_abatimento, double doc_juros, double doc_saldo, double total)
        {
            this.doc_venciment = doc_venciment;
            this.doc_doc = doc_doc;
            this.doc_serie = doc_serie;
            this.doc_parcela = doc_parcela;
            this.doc_emissao = doc_emissao;
            this.doc_clifor = doc_clifor;
            this.doc_razao = doc_razao;
            _conta = conta;
            this.doc_obs = doc_obs;
            this.doc_valor = doc_valor;
            this.doc_abatimento = doc_abatimento;
            this.doc_juros = doc_juros;
            this.doc_saldo = doc_saldo;
            this.total = total;
        }
        public RegPag()
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
            this.doc_obs = "";
            this.doc_valor = 0;
            this.doc_abatimento = 0;
            this.doc_juros = 0;
            this.doc_saldo = 0;
            this.total = 0;
        }
    }
}
