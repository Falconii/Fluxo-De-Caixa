using System;

namespace Fluxo_De_Caixa.Models
{
    public class Conta
    {

        public int IdEmpresa { get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int UserInsert { get; set; }
        public int UserUpdate { get; set; }

        public Conta(int idEmpresa, string codigo, string tipo, string descricao, int userInsert, int userUpdate)
        {
            IdEmpresa = idEmpresa;
            Codigo = codigo;
            Tipo = tipo;
            Descricao = descricao;
            UserInsert = userInsert;
            UserUpdate = userUpdate;
        }

        public Conta()
        {
            Zerar();
        }
       
        public void Zerar()
        {
            IdEmpresa   = 1;
            Codigo      = "";
            Tipo        = "";
            Descricao = "";
            UserInsert = 0;
            UserInsert = 0;
        }
    }
}
