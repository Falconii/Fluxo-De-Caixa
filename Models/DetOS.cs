using System;

namespace Fluxo_De_Caixa.Models
{
    public class DetOS
    {
        public int Id_Empresa { get; set; }
        public int Id_Os { get; set; }
        public int Item { get; set; }
        public double Qtd { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int User_Insert { get; set; }
        public int User_Update { get; set; }

        public DetOS(int id_Empresa, int id_Os, int item, double qtd, string descricao, double valor, int user_Insert, int user_Update)
        {
            Id_Empresa = id_Empresa;
            Id_Os = id_Os;
            Item = item;
            Qtd = qtd;
            Descricao = descricao;
            Valor = valor;
            User_Insert = user_Insert;
            User_Update = user_Update;
        }

        public DetOS()
        {
            Zerar();
        }
          

        public void Zerar()
        {
            Id_Empresa = 1;
            Id_Os = 0;
            Item = 0;
            Qtd = 0;
            Descricao = "";
            Valor = 0;
            User_Insert = 0;
            User_Update = 0;
        }
    }
}
