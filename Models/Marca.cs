using System;

namespace Fluxo_De_Caixa.Models
{
    public class Marca
    {

        public int Id_Empresa { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int User_Insert { get; set; }
        public int User_Update { get; set; }

        public Marca(int id_Empresa, int id, string descricao, int user_Insert, int user_Update)
        {
            Id_Empresa = id_Empresa;
            Id = id;
            Descricao = descricao;
            User_Insert = user_Insert;
            User_Update = user_Update;
        }

        public Marca()
        {
            Zerar();
        }
       
        public void Zerar()
        {
            Id_Empresa   = 1;
            Id = 0;
            Descricao = "";
            User_Insert = 0;
            User_Insert = 0;
        }
    }
}
