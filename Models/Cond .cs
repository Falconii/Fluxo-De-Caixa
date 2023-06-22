using System;

namespace Fluxo_De_Caixa.Models
{
    public class Cond
    {
        public int Id_Empresa { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Nro_Parcelas { get; set; }
        public string Inter1 { get; set; }
        public string Inter2 { get; set; }
        public int User_Insert { get; set; }
        public int User_Update { get; set; }

        public Cond(int id_Empresa, int id, string descricao, int nro_Parcelas, string inter1, string inter2, int user_Insert, int user_Update)
        {
            Id_Empresa = id_Empresa;
            Id = id;
            Descricao = descricao;
            Nro_Parcelas = nro_Parcelas;
            Inter1 = inter1;
            Inter2 = inter2;
            User_Insert = user_Insert;
            User_Update = user_Update;
        }

        public Cond()
        {
            Zerar();
        }
          

        public void Zerar()
        {
            Id_Empresa = 0;
            Id = 0;
            Descricao = "";
            Nro_Parcelas = 0;
            Inter1 = "";
            Inter2 = "";
            User_Insert = 0;
            User_Update = 0;
        }
    }
}
