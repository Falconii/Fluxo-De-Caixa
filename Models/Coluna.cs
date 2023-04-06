using System;

namespace Fluxo_De_Caixa.Models
{
    public class Coluna
    {
        public int User { get; set; }
        public int Indice { get; set; }
        public string Nome { get; set; }
        public int Tam { get; set; }
        public System.Windows.Forms.DataGridViewContentAlignment Alinhamento { get; set; }
        public string Formatacao { get; set; }
        public Boolean Visible { get; set; }

        public Coluna()
        {
            Zerar();
        }

        public void Zerar()
        {
            User = 0;
            Indice = 0;
            Nome = "";
            Tam = 100;
            Alinhamento = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            Formatacao = "";
            Visible = true;
    }
    }
}
