using System;

namespace Fluxo_De_Caixa.Models
{
    public class Detalhe
    {
        public int Item { get; set; }
        public double Qtd { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }

        public Detalhe(int item, double qtd, string descricao, double valor)
        {
            Item = item;
            Qtd = qtd;
            Descricao = descricao;
            Valor = valor;
        }

        public Detalhe()
        {
            Zerar();
        }
          

        public void Zerar()
        {   Item = 0;
            Qtd = 0;
            Descricao = "";
            Valor = 0;
        }
    }
}
